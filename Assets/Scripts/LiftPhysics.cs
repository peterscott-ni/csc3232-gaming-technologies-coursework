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
            var posY = player.transform.position.y;            player.transform.Translate(transform.up * Time.fixedDeltaTime * 0.4f);
            // Move Player upwards
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(transform.position.x, posY, transform.position.z), 0.005f);
            // Rotate Player
            player.transform.Rotate(Vector3.up * Time.deltaTime * 300);

            /*        Rigidbody rb = player.GetComponent<Rigidbody>();
                        rb.AddForce(Vector3.up * 0.1f, ForceMode.Impulse);*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsColliding = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsColliding = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
