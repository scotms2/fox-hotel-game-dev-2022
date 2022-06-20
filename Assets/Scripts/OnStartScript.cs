using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartScript : MonoBehaviour
{
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameSettings = GameObject.Find("GameSettings");
        if(gameSettings != null)
        {
            if(!gameSettings.GetComponent<GameSettings>().firstTime)
            {
                dialogueBox.SetActive(false);
            }
            else {
                dialogueBox.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
