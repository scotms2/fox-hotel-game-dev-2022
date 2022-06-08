using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceTimer2 : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Gold gold;
    public Animator animator;
    private bool temp = true;
    public GameObject timerPrefab;
    private Guest2 guest;

    void Start()
    {
        timerIsRunning = true;
        guest = GetComponent<Guest2>();
        animator.enabled = false;
    }

    void Update() 
    {
        if(guest.idle)
        {
            timerStart();
        }    
    }

    void timerStart()
    {
        if (temp == true)
        {
            send();
            temp = false;
        }
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
                //Destroy(gameObject);
            }
        }
    }

    public void send()
    {
        timerPrefab  = Instantiate(timerPrefab, new Vector3(0.056f,0.021f,0.174f), timerPrefab.transform.rotation);
        timerPrefab.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
    }
}
