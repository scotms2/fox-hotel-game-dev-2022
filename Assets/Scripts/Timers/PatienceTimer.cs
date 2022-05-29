using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatienceTimer : MonoBehaviour
{
    public float timeRemaining;
    public float _timeRemaining;
    public bool timerIsRunning = false;
    public Gold gold;
    public Animator animator;
    public string scenename;
    
    void OnMouseUp()
    {
        if (animator.gameObject.GetComponent<Animator>().enabled == false)
            SceneManager.LoadSceneAsync(scenename);
    }


    void Start()
    {
        timerIsRunning = true;
        _timeRemaining = timeRemaining;
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
               // Debug.Log("Patience Timer:" + timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Destroy(gameObject);
            }
        }
    }
}
