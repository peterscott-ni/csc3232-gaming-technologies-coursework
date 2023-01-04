using ConsoleApp2.probabilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public GameObject timeLogic;

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
            string key = "";
            switch (gameObject.name)
            {
                case "KeyA": key = "Key A"; break;
                case "KeyB": key = "Key B"; break;
                case "KeyC": key = "Key C"; break;
                case "KeyD": key = "Key D"; break;
            }
            //gameObject.GetComponent<Renderer>().enabled = false;
            //timeLogic.GetComponent<TimeLogic>().UpdateText(key, tmp);
            timeLogic.GetComponent<TimeLogic>().SendText("Obtained " + key, tmp);
            //StartCoroutine(UpdateText(key));
            gameObject.SetActive(false);
        }
    }

    //IEnumerator UpdateText(string key)
    //{
    //    Debug.Log("Collected Key");
    //    tmp.gameObject.SetActive(true);
    //    tmp.text = "Obtained " + key;
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("Waiting time up");
    //    tmp.gameObject.SetActive(false);
    //}
}
