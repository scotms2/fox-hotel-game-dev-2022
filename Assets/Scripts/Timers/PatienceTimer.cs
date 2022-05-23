using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatienceTimer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Gold gold;
    public Animator animator;
    public string scenename;
    void OnMouseUp()
    {
        if (animator.gameObject.GetComponent<Animator>().enabled == false)
            //GameObject.Find("DayTime").GetComponent<DayTimer>().LoadGame();
            SceneManager.LoadScene(scenename);
    }


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
            if(gold.m_Time > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log("Patience Timer:" + timeRemaining);
            }
            else
            {
                gold.m_Time = 0;
                timerIsRunning = false;
                Destroy(gameObject);
            }
        }
    }
}
