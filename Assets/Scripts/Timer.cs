using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;

    public TextMeshProUGUI dayTimerText;    //Textmesh pro day timer ref

    public TextMeshProUGUI dayOrNightText;    //Textmesh pro day or night ref

    public GameObject endDayButton;

    public bool timerIsRunning = false;

    public bool day = false;
    public bool night = false;

    private bool oneTime = false;

    void Start()
    {
        timerIsRunning = true;  //set timerIsRunning to true
        day = true; //Make it day time when game is started
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning && day)  //if true
        {
            if(timeRemaining > 0)   //if timer is greater than 0
            {
                timeRemaining -= Time.deltaTime;    //start counting down
                DisplayTime(timeRemaining); //display timer on canvas (replacing text every second/frame)
            }
            else    //when timer has finished
            {
                Debug.Log("Day time has ended");
                timeRemaining = 0;  //set timer to 0 so it doesnt keep going down after reaching zero
                dayTimerText.text = "Day Timer: 00:00";
                timerIsRunning = false; //set timerIsRunning to false
                day = false;
                night = true;
            }
        }

        DayOrNight();
        if(night)
        {
            if(!oneTime)
            {
                GenerateEndDayButton();
                oneTime = true;
            }
        }
    }

    private void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(displayTime / 60); //Calc minutes to display
        float seconds = Mathf.FloorToInt(displayTime % 60);     //Calc seconds to display
        dayTimerText.text = string.Format("Day Timer: {0:00}:{1:00}", minutes, seconds);    //Overwrite current text with new text displaying current timer progress
    }

    private void DayOrNight()
    {
        if(day)
        {
            dayOrNightText.text = "It Is Currently: Day Time";
        }
        else
        {
            dayOrNightText.text = "It is Currently: Night Time";
        }
    }

    private void GenerateEndDayButton()
    {
        GameObject newButton = Instantiate(endDayButton) as GameObject;
        newButton.transform.SetParent(this.transform, false);
    }
}
