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
    private bool temp = true;

    public GameObject timerPrefab;
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

    public void timerStart()
    {
        if (temp == true)
        {
            send();
            temp = false;
        }
        if (timerIsRunning)
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
                Destroy(gameObject);
            }
        }
    }
    public void send()
    {
        timerPrefab  = Instantiate(timerPrefab, new Vector3(0.056f,0.021f,0.174f), timerPrefab.transform.rotation);
        timerPrefab.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
    }
}
