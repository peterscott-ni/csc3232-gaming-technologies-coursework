using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MathNet.Numerics;

public class TimeLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendText(string message, TextMeshProUGUI tmp)
    {
        Debug.Log("Reached TimeLogic");
        StartCoroutine(UpdateText(message, tmp));
    }

    IEnumerator UpdateText(string message, TextMeshProUGUI tmp)
    {
        Debug.Log("Collected Key");
        tmp.gameObject.SetActive(true);
        tmp.text = message;
        yield return new WaitForSeconds(3f);
        Debug.Log("Waiting time up");
        tmp.gameObject.SetActive(false);
    }
}
