using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxComponent : MonoBehaviour, IDragHandler, IPointerClickHandler, IEndDragHandler
{
    public Vector3 default_position;
    public float z;
    public RectTransform dragRangeRect;
    RectTransform rectTrans;
    public bool isEnter = false;
    public Vector3 lasePosition;
    public bool isChangePos = true;
    private void Awake()
    {
        rectTrans = this.GetComponent<RectTransform>();
    }
    void Start()
    {
        default_position = this.transform.position;
        z = this.transform.rotation.z;
    }
    private void Update()
    {
        WaitTimeManager.WaitTime(2, delegate
        {
            lasePosition = this.transform.position;
        });
       
        if (lasePosition==this.transform.position)
        {
            isChangePos = false;
        }
        else
        {
            isChangePos = true; ;
        }
        
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
        if (isEnter == false)
        {
            this.transform.position = default_position;
        }
        else
        {
            var pos = GameSystem.instance.CabinetComponent.GetNearestPos(rectTrans.position);
            rectTrans.position = pos;
            lasePosition = this.transform.position;
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
    private void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
