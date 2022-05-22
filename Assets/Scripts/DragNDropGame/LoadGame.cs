using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    //[SerializeField] private string miniGameScene;
    //[SerializeField] private string mainDemoScene;

    void OnMouseUp()
    {
        GameObject.Find("DayTime").GetComponent<DayTimer>().LoadGame();
    }

    public void back()
    {
        GameObject.Find("DayTime").GetComponent<DayTimer>().StartGame();
    }
}
