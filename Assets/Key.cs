using ConsoleApp2.probabilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /*private bool hasKeyA = false;
    private bool hasKeyB = false;
    private bool hasKeyC = false;
    private bool hasKeyD = false;

    private bool[] hasKeys = { false, false, false, false };

    private bool[] doorsOpen = { false, false, false, false };*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*for(int i = 0; i < hasKeys.Length; i++)
        {
            if (doorsOpen[i] == true)
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*switch (gameObject.name)
            {
                case "KeyA": hasKeys[0] = true; break;
                case "KeyB": hasKeys[1] = true; break;
                case "KeyC": hasKeys[2] = true; break;
                case "KeyD": hasKeys[3] = true; break;
            }*/
            gameObject.SetActive(false);
        }
    }
}
