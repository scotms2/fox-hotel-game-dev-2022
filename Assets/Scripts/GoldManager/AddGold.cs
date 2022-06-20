using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AddGold : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private int money;
    public Gold Gold;

    // Start is called before the first frame update
    void Start()
    {
        //txt = GameObject.Find("Canvas/Text").GetComponent<TextMeshProUGUI>();
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //txt.text = "Gold: " + money.ToString();
        txt.text = Gold.score.ToString();

    }

    //1
    public void IncreaseGold()
    {
        Debug.Log("Calling from the Increase Gold Method");
        Gold.score += 50;
    }

    public void ExitGame()
    {
        Gold.score = 0;
        Gold.m_Time = 40;
        Gold.IsDisPlayer = false;
        Gold.currclient = 0;
        #if UNITY_EDITOR 

                UnityEditor.EditorApplication.isPlaying = false;
        #else
                                    Application.Quit();
        #endif
    }
}
