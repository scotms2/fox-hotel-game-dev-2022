using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceTimer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
        
    }

    void timerStart()
    {
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
            }
        }
    }
}
