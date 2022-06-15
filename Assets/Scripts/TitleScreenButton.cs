using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenButton : MonoBehaviour
{
    public bool gameStart;

    void Start()
    {
        gameStart = false;
    }

    public void gameStartButton()
    {
        gameStart = true;
    }
}
