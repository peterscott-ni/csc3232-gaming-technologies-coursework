using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class FireflyFlocking : MonoBehaviour
{
    public GameObject fireflyTarget;
    private GameObject localTarget;

    private GameObject[] fireflyArray;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        fireflyArray = GameObject.FindGameObjectsWithTag("Firefly");
        rb = this.GetComponent<Rigidbody>();
        localTarget = new GameObject();
        SetLocalTarget();
    }

    // Update is called once per frame
    void Update()
    {
        var distanceFromLocalTarget = Vector3.Distance(localTarget.transform.position, transform.position);
        if (distanceFromLocalTarget <= 0.25f)
        {
            SetLocalTarget();
        }
        MoveTowardTarget();
/*        SeparateFireflies();
*/    }

    private void OnCollisionStay(Collision collision)
    {
        SetLocalTarget();
    }

    private void SetLocalTarget()
    {
        localTarget.transform.position = fireflyTarget.transform.position + (Random.insideUnitSphere) * 0.5f;
    }

    private void MoveTowardTarget()
    {
        Vector3 direction = localTarget.transform.position - transform.position;
        rb.AddForce(direction*0.05f, ForceMode.Force);
        /*        transform.Translate(direction * Time.deltaTime);
        */
        /*Vector3 randomMotion = new Vector3(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f), Random.Range(0.0f, 0.1f));
        rb.AddForce(randomMotion, ForceMode.Force);*/
        if (rb.velocity.magnitude >= 0.1f)
        {
            rb.velocity = rb.velocity.normalized * 0.1f;
        }
    }

    private void SeparateFireflies()
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
                /*float distance = Vector3.Distance(firefly.transform.position, transform.position);
                 if(distance <= 0.1f)
                 {
                     Vector3 direction = transform.position - firefly.transform.position;
                     transform.Translate(direction * Time.deltaTime);
                 }   */
                /*                totalVector += (firefly.transform.position - transform.position);
*/
            }

        }
        /*Vector3 averageVector = totalVector / (fireflyArray.Length - 1);
        if(Vector3.Distance(averageVector, transform.position) <= 0.2f)
        {
            rb.AddForce(-averageVector, ForceMode.Force);
        }*/
    }
}
