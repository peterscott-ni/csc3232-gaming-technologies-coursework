using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 360;
    private bool timerIsRunning;
    public TextMeshProUGUI tmpTimer;
    public TextMeshProUGUI tmpLoseGame;

    // Start is called before the first frame update
    void Start()
    {
        tmpTimer.enabled = false;
        tmpLoseGame.enabled = false;
    }

    public void StartTimer()
    {
        timerIsRunning = true;
        tmpTimer.enabled = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if (timeRemaining > 1f)
            {
                timeRemaining -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                if (seconds < 10)
                    tmpTimer.text = "Time left: " + minutes + ":0" + seconds;
                else
                    tmpTimer.text = "Time left: " + minutes + ":" + seconds;
            }
            else
            {
                timerIsRunning = false;
                LoseGame();
            }
        }
    }

    private void LoseGame()
    {
        tmpTimer.text = "Time left: 0:00";
        tmpLoseGame.enabled = true;
    }
}
