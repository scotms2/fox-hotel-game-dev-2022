using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GoldButton : MonoBehaviour
{
    public Button btn;
    public Text txt;
    private int gold;
    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.Find("Canvas/GoldButton").GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        gold = GameObject.Find("Managers/Gold").GetComponent<Gold>().Golds;
        txt = GameObject.Find("Canvas/Text").GetComponent<Text>();
        txt.text = "Gold: " + gold.ToString();

    }

    public void OnClick()
    {
        // txt.text = gold.ToString();
        txt.text = "123";

    }
}
