using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatienceTimer2 : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Gold gold;
    private bool temp = true;
    [SerializeField] private Image uiFill;
    private Guest guest;

    public GameObject circle;

    private float maxTime;

    public Color three_quarter;
    public Color half;
    public Color quarter;

    public TextMeshProUGUI text;

    private Vector3 startPos;

    void OnEnable()
    {
        startPos = transform.position;
        timerIsRunning = true;
        maxTime = timeRemaining;
        guest = GetComponent<Guest>();
        circle.SetActive(false);
    }

    void Update() 
    {
        if(guest.reachedPoint1)
        {
            timerStart();
        }    
    }

    void timerStart()
    {
        if (temp == true)
        {
            circle.SetActive(true);
            temp = false;
        }
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                float fillRatio = timeRemaining / maxTime;
                timeRemaining -= Time.deltaTime;
                if(fillRatio <= 0.75)
                {
                    text.color = three_quarter;
                    uiFill.color = three_quarter;
                }
                if(fillRatio <= 0.5)
                {
                    text.color = half;
                    uiFill.color = half;
                }
                if(fillRatio <= 0.25)
                {
                    text.color = quarter;
                    uiFill.color = quarter;
                }
                uiFill.fillAmount = fillRatio;
                Debug.Log("Patience Timer:" + timeRemaining);
            }
            else
            {
                timeRemaining = maxTime;
                timerIsRunning = false;
                circle.SetActive(false);
                gameObject.transform.position = startPos;
                guest.isMoving = true;
                guest.reachedPoint1 = false;
            }
        }
    }

    // public void send()
    // {
    //     timerPrefab  = Instantiate(timerPrefab, new Vector3(0.056f,0.021f,0.174f), timerPrefab.transform.rotation);
    //     timerPrefab.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
    // }
}
