using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameSettings = GameObject.Find("GameSettings");
        if(gameSettings != null)
        {
            gameSettings.GetComponent<GameSettings>().firstTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
