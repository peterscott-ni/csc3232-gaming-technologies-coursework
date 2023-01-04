using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public TextMeshPro tmp;

    public GameObject keyA;
    public GameObject keyB;
    public GameObject keyC;
    public GameObject keyD;
    public GameObject[] fireflies;


    // Start is called before the first frame update
    void Start()
    {
        tmp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tmp.gameObject.SetActive(true);
            GameObject key = GetKey();
            Debug.Log("Key to check: " + key.name.ToString());
            if (key.activeSelf) // key has not yet been found
            {
                tmp.text = "The door is locked\nFind a key!";
            }
            else // key has been found
            {
                tmp.text = "Press E to unlock door";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tmp.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            //check if player has the correct key
            GameObject key = GetKey();
            if(!key.activeSelf)
            {
                gameObject.SetActive(false); // door opens
            }
        }
    }

    private GameObject GetKey()
    {
        switch (gameObject.name)
        {
            case "MazeDoorA": Debug.Log("Approached MazeDoorA"); return keyA;
            case "MazeDoorB": Debug.Log("Approached MazeDoorB"); return keyB;
            case "MazeDoorC": Debug.Log("Approached MazeDoorC"); return keyC;
            case "MazeDoorD": Debug.Log("Approached MazeDoorD"); return keyD;
            default: throw new System.Exception();
        }
    }
}
