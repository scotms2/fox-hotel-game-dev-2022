using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCompletedEvent : MonoBehaviour
{
    public bool isEnter = false;
    public GameObject obj;
    public bool IsNot;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsNot)
            return;
        if (other.gameObject.GetComponent<BoxComponent>()&&!isEnter&&obj==null)
        {
            obj = other.gameObject;
            isEnter = true;
            other.gameObject.GetComponent<BoxComponent>().isEnter += 1;
            other.gameObject.transform.SetParent(GameSystem.instance.Panel_Box.transform);
            GameSystem.instance.boxList.Add(other.gameObject.GetComponent<BoxComponent>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsNot)
            return;
        if (other.gameObject== obj)
        {
            isEnter = false;
            if (other.gameObject.GetComponent<BoxComponent>().isEnter > 0)
                other.gameObject.GetComponent<BoxComponent>().isEnter -= 1;
            other.gameObject.transform.SetParent(GameSystem.instance.Panel_Left.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate(GameSystem.instance.Panel_Left.GetComponent<RectTransform>());
            GameSystem.instance.boxList.Remove(other.gameObject.GetComponent<BoxComponent>());
            obj = null;
        }
    }
}