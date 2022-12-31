using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool playerIsColliding = false;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(playerIsColliding)
        {
/*            player.transform.Translate(transform.up * Time.fixedDeltaTime);
*/      
        Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsColliding = false;
        }
    }
}
