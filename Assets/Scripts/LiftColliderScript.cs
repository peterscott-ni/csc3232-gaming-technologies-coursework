using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");

        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(-4, 5, 0), ForceMode.Impulse);
            Debug.Log("YEET");

        }
    }
}
