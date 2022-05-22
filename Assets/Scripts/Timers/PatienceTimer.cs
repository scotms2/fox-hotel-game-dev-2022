using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceTimer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;

    public Animator animator;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update() 
    {
        if(animator.gameObject.GetComponent<Animator>().enabled == false)
        {
            timerStart();
        }    
    }

    void timerStart()
    {
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log("Patience Timer:" + timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
