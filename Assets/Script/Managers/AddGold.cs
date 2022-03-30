using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddGold : MonoBehaviour
{
    public Text txt;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("Canvas/Text").GetComponent<Text>();
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Gold: " + money.ToString();
    }

    //1
    void OnMouseUp()
    {
        money += 50;
    }
}
