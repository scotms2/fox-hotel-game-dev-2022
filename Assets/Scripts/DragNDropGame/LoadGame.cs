using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public Gold Gold;
    public string scenename;
    //[SerializeField] private string mainDemoScene;


    public void back()
    {
        GameObject.Find("DayTime").GetComponent<DayTimer>().StartGame();
    }
}
