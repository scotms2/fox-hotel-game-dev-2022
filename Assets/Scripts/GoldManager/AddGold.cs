using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AddGold : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        //txt = GameObject.Find("Canvas/Text").GetComponent<TextMeshProUGUI>();
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Gold: " + money.ToString();
    }

    //1
    public void IncreaseGold()
    {
        money += 50;
    }
}
