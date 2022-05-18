using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEndDay : MonoBehaviour
{
    public GameObject endDayButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ButtonClick()
    {
        //when click button, go to day mode. destroy button and reset every thing in DayTimer script.
        //Destroy(endDayButton);
        //Debug.Log("click end day button");
        endDayButton.SetActive(false);

        GameObject.Find("DayTime").gameObject.GetComponent<DayTimer>().Reset();
    }
}
