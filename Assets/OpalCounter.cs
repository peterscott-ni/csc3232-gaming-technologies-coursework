using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpalCounter : MonoBehaviour
{
    private int opalCount;
    public TextMeshProUGUI tmpWin;
    public TextMeshProUGUI tmpOpalCount;

    // Start is called before the first frame update
    void Start()
    {
        tmpWin.enabled = false;
        tmpOpalCount.enabled = false;
        opalCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayOpalCounter()
    {
        tmpOpalCount.enabled = true;
    }

    public void AddOpal()
    {
        opalCount++;
        tmpOpalCount.text = "Opals collected: " + opalCount.ToString();
        if (opalCount == transform.childCount)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        GameObject.Find("Timer").GetComponent<Timer>().StopTimer();
        tmpWin.enabled = true;
    }
}
