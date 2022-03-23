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
        money = GameObject.Find("Managers/Gold").GetComponent<Gold>().Golds;

    }

    // Update is called once per frame
    void Update()
    {
        
        money = GameObject.Find("Managers/Gold").GetComponent<Gold>().Golds;
        txt.text = "Gold: " + money.ToString();
    }

    //1
    void OnMouseUp()
    {
        money += 50;
        // GameObject.Find("Managers/Gold").GetComponent<Gold>().Golds += 50;    
    }




}
