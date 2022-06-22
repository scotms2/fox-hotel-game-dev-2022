using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCompletedEvent : MonoBehaviour
{
    public bool isEnter = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isEnter = true;
        if (other.gameObject.GetComponent<BoxComponent>())
        {
            other.gameObject.GetComponent<BoxComponent>().isEnter += 1;
            other.gameObject.transform.SetParent(GameSystem.instance.Panel_Box.transform);
            GameSystem.instance.boxList.Add(other.gameObject.GetComponent<BoxComponent>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEnter = false;
        other.gameObject.GetComponent<BoxComponent>().isEnter -= 1;
        other.gameObject.transform.SetParent(GameSystem.instance.Panel_Left.transform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GameSystem.instance.Panel_Left.GetComponent<RectTransform>());
        GameSystem.instance.boxList.Remove(other.gameObject.GetComponent<BoxComponent>());
    }
}