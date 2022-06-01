using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isCan = false;
    private RectTransform rectTransform;

    public Transform targerTF;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        pos = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isCan)
        {
            return;
        }
          
            Debug.Log("Drag");
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isCan)
        {
            return;
        }
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.enterEventCamera, out pos);
        rectTransform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isCan)
        {
            return;
        }
        if (triggTrans != null && triggTrans == targerTF)
        {

          var   manager = GameObject.Find("DragManager").GetComponent<DragManager>();
            manager.number++;
            this.transform.position = targerTF.position;
            isCan = false;
        }
        else
        {
            transform.position = pos;
        }

    }

    private bool isOver = false;
    private Transform triggTrans;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Yes")
        {
            isOver = true;
            triggTrans = collision.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Yes")
        {
            isOver = true;
            triggTrans = collision.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
