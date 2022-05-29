using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCompletedEvent : MonoBehaviour
{
    public bool isEnter = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEnter = false;
    }
}