using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject Panel_Start;
    public Button btn_start;

    private void Awake()
    {
        gameManager = this;
    }

    void Start()
    {
        if (Panel_Start!=null)
        {
            btn_start.onClick.AddListener(delegate
            {
                Panel_Start.SetActive(false);
            });
        }
    }
}
