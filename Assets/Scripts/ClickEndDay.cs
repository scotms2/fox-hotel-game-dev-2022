using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEndDay : MonoBehaviour
{
    //public GameObject endDayButton;

    public DayTimer DayTimeScript;
    
    public void ButtonClick()
    {
        //when click button, go to day mode. destroy button and reset every thing in DayTimer script.
        gameObject.SetActive(false);
        DayTimeScript.Reset();
    }
}
