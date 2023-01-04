using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeExitTrigger : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject cinemachineCamera;
    public GameObject orientation;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
            cinemachineCamera.SetActive(true);


            other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            orientation.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

        }
    }
}
