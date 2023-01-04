using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftColliderScript : MonoBehaviour
{
    public GameObject[] fireflies;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "LiftColliderFireflies")
        {
            foreach (GameObject firefly in fireflies)
            {
                firefly.SetActive(false);
            }
            return;
        }
        Debug.Log("Collided");

        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(-4, 5, 0), ForceMode.Impulse);
            Debug.Log("YEET");
            GameObject.Find("Opals").GetComponent<OpalCounter>().DisplayOpalCounter();

        }
    }
}
