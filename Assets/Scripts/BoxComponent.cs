using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxComponent : MonoBehaviour, IDragHandler, IPointerClickHandler, IEndDragHandler
{
    public string id;
    public float z;
    public RectTransform dragRangeRect;
    RectTransform rectTrans;
    public bool isEnter = false;
    public Vector3 lasePosition;

    public bool isDown = false;
   // public bool isChangePos = true;
    private void Awake()
    {
        rectTrans = this.GetComponent<RectTransform>();
        string[] names = gameObject.name.Split("_");
        id =names[1];
    }
    void Start()
    {
        z = this.transform.rotation.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            this.transform.position = Input.mousePosition;
        }

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GameSystem.instance.BagplacedAudioSource.Play();
        if (isEnter == false)
        {
            this.transform.SetParent(GameSystem.instance.Panel_Left.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate(GameSystem.instance.Panel_Left.GetComponent<RectTransform>());
            isDown = false;
        }
        else
        {
            var pos = GameSystem.instance.CabinetComponent.GetNearestPos(rectTrans.position);
            rectTrans.position = pos;
            isDown = true;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isEnter==false)
            {
                this.transform.Rotate(0, 0, this.transform.rotation.z - 90);
            }
        }
    }
}
