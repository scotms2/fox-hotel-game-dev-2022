using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetComponent : MonoBehaviour
{
    public Transform parentTrans;
    public int gridItemCount;
    public GameObject childObj;
    public string gridId;
    public List<RectTransform> allChildGrid = new List<RectTransform>();
    public List<BoxComponent> boxDefault = new List<BoxComponent>();
  
   public string[] boxId;
   
    private void Start()
    {
        InstantiateGrid();
    }

    public void InstantiateGrid()
    {
        for (int i = 0; i < gridItemCount; i++)
        {
            var obj = Instantiate(childObj);
            obj.name = (i + 1).ToString();
            obj.transform.SetParent(parentTrans);
            allChildGrid.Add(obj.GetComponent<RectTransform>());
        }

        string[] grids = gridId.Split(',');
        foreach (var item in grids)
        {
            foreach (var grid in allChildGrid)
            {
                if (item==grid.name)
                {
                    grid.GetComponent<BoxCompletedEvent>().isEnter = true;
                    grid.GetComponent<BoxCollider2D>().isTrigger = false;
                    
                }
            }
        }

        foreach (var item in boxDefault)
        {
            item.transform.SetParent(GameSystem.instance.Panel_Box.transform);
            GameSystem.instance.boxList.Add(item);
            item.GetComponent<Image>().raycastTarget = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxComponent>())
        {
            collision.gameObject.GetComponent<BoxComponent>().isEnter = true;
            collision.gameObject.transform.SetParent(GameSystem.instance.Panel_Box.transform);
            GameSystem.instance.boxList.Add(collision.gameObject.GetComponent<BoxComponent>());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BoxComponent>().isEnter = false;
        collision.gameObject.transform.SetParent(GameSystem.instance.Panel_Left.transform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GameSystem.instance.Panel_Left.GetComponent<RectTransform>());
        GameSystem.instance.boxList.Remove(collision.gameObject.GetComponent<BoxComponent>());
    }
    public Vector3 GetNearestPos(Vector3 pos)
    {
        float minDis = float.MaxValue;
        Vector3 returnPos = Vector3.zero;
        foreach (var child in allChildGrid)
        {
            var dis = Vector3.Distance(child.position, pos);
            if (dis < minDis)
            {
                minDis = dis;
                returnPos = child.position;
            }
        }
        return returnPos;
    }
}
