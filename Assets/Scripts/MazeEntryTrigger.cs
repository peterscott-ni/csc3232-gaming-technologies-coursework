using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEntryTrigger : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject cinemachineCamera;
    public GameObject orientation;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            firstPersonCamera.SetActive(true);
            thirdPersonCamera.SetActive(false);
            cinemachineCamera.SetActive(false);

            
            other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            orientation.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            Camera fpc = firstPersonCamera.GetComponent<Camera>();
            //fpc.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

            
           /* Camera fpc = firstPersonCamera.GetComponent<Camera>();
            Camera tpc = thirdPersonCamera.GetComponent<Camera>();

            fpc.enabled = true;*/

        }
    }
}
