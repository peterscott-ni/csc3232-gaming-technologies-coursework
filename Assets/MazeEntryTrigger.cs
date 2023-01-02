using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEntryTrigger : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject cinemachineCamera;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            firstPersonCamera.SetActive(true);
            thirdPersonCamera.SetActive(false);
            cinemachineCamera.SetActive(false);
           /* Camera fpc = firstPersonCamera.GetComponent<Camera>();
            Camera tpc = thirdPersonCamera.GetComponent<Camera>();

            fpc.enabled = true;*/

        }
    }
}
