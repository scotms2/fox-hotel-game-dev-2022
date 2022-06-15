using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;
    public static GameSettings Instance
    {
        get { return instance; }
    }
    public bool firstTime = true;
    private void Awake()
    {
        if (instance == null)        
            instance = this;        
        else if (instance != this)        
            Destroy(this); 
        DontDestroyOnLoad(gameObject);  
    }
}
