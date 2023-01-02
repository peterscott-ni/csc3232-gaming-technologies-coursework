using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class FireflyFlocking : MonoBehaviour
{
    public GameObject fireflyTarget;
    private GameObject localTarget;

    private GameObject[] fireflyArray;
    private Rigidbody rb;

    private NavMeshAgent agent;
    private bool pathfindingEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        agent.destination = fireflyTarget.transform.position;
        agent.enabled = false;
        // fireflyArray = GameObject.FindGameObjectsWithTag("Firefly");
        rb = this.GetComponent<Rigidbody>();
        localTarget = new GameObject();
        SetLocalTarget();
    }

    // Update is called once per frame
    void Update()
    {
        var distanceFromLocalTarget = Vector3.Distance(localTarget.transform.position, transform.position);
        var distanceFromTarget = Vector3.Distance(fireflyTarget.transform.position, transform.position);

        if (pathfindingEnabled) // pathfinding has been enabled after colliding with wall
        {
            agent.enabled = true;
/*            Debug.Log("Pathfinding is active");
*/            if (distanceFromTarget<= 1.5f) // regrouped with target
            {
                agent.enabled = false;
                pathfindingEnabled = false;
                SetLocalTarget();
                MoveTowardTarget();
                return;
            }
            var currentFireflyLocation = transform.position;
            agent.transform.position = new Vector3(currentFireflyLocation.x, 0, currentFireflyLocation.z);
            transform.position = currentFireflyLocation;
            rb.velocity = Vector3.zero;
            agent.destination = fireflyTarget.transform.position;
            return;
        }
        if (distanceFromLocalTarget <= 0.5f || distanceFromTarget >= 1.5f)
        {
            SetLocalTarget();
        }
        MoveTowardTarget();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            ActivatePathfinding();
        }
    }

    private void ActivatePathfinding()
    {
        pathfindingEnabled = true;
        Debug.Log("Pathfinding enabled");
    }

    private void SetLocalTarget()
    {
        localTarget.transform.position = fireflyTarget.transform.position + (Random.insideUnitSphere) * 0.4f;
    }

    [SerializeField] public float movementForce;
    [SerializeField] public float maxSpeed;
    private void MoveTowardTarget()
    {
        Vector3 direction = localTarget.transform.position - transform.position;
        rb.AddForce(direction * movementForce, ForceMode.Force);
        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

/*    private void SeparateFireflies()
    {
        Vector3 totalVector = Vector3.zero;
        foreach(GameObject firefly in fireflyArray)
        {
            if(firefly != gameObject) // avoids performing calculation for self
            { 
                float currentNeighbourDistanceSqr = Vector3.SqrMagnitude(firefly.transform.position - transform.position);
                if(currentNeighbourDistanceSqr <= (0.1f * 0.1f))
                {
                    Vector3 direction = firefly.transform.position - transform.position;
                    rb.AddForce(-direction.normalized * 0.4f, ForceMode.Force);
                }
                *//*float distance = Vector3.Distance(firefly.transform.position, transform.position);
                 if(distance <= 0.1f)
                 {
                     Vector3 direction = transform.position - firefly.transform.position;
                     transform.Translate(direction * Time.deltaTime);
                 }   */
                /*                totalVector += (firefly.transform.position - transform.position);
*//*
            }

        }
        *//*Vector3 averageVector = totalVector / (fireflyArray.Length - 1);
        if(Vector3.Distance(averageVector, transform.position) <= 0.2f)
        {
            rb.AddForce(-averageVector, ForceMode.Force);
        }*//*
    }*/
}
