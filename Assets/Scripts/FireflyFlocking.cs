using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyFlocking : MonoBehaviour
{
    public GameObject fireflyTarget;

    private GameObject[] fireflyArray;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        fireflyArray = GameObject.FindGameObjectsWithTag("Firefly");
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardTarget();
        SeparateFireflies();
    }

    private void MoveTowardTarget()
    {
        Vector3 direction = fireflyTarget.transform.position - transform.position;
        transform.Translate(direction * Time.deltaTime);
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
        Vector3 averageVector = totalVector / (fireflyArray.Length - 1);
        if(Vector3.Distance(averageVector, transform.position) <= 0.2f)
        {
            rb.AddForce(-averageVector, ForceMode.Force);
        }
    }
}
