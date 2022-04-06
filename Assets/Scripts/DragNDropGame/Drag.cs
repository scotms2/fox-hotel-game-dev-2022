using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform orignaParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        orignaParent = transform.parent;//确定初始父节点
        transform.SetParent(transform.parent.parent.parent);//改变父节点
        transform.position = eventData.position;// let the picture follow mouse
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject.name == "Image") //检测到目标对象为Image
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent); //将对象的父亲设为目标对象的父亲
            transform.position =
                eventData.pointerCurrentRaycast.gameObject.transform.parent.position; //将对象的位置变成目标对象父亲的位置
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(orignaParent); //改变目标对象的父亲为初始父亲
            eventData.pointerCurrentRaycast.gameObject.transform.position = orignaParent.position; //将目标对象的位置变成初始父亲的位置
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "Item") //检测到目标对象为Item
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform); //将此对象的父亲设置为目标对象的
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position; //将此对象的位置设为目标对象的位置
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }

        transform.SetParent(orignaParent); //恢复父节点
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
