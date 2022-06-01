using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetComponent : MonoBehaviour
{
    public Transform parentTrans;
    public int gridItemCount;
    public GameObject childObj;
    List<RectTransform> allChildGrid = new List<RectTransform>();
    private void Start()
    {
        for (int i = 0; i < gridItemCount; i++)
        {
            var obj = Instantiate(childObj);
            obj.transform.SetParent(parentTrans);
            allChildGrid.Add(obj.GetComponent<RectTransform>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxComponent>())
        {
            collision.gameObject.GetComponent<BoxComponent>().isEnter = true;
            if (!collision.gameObject.GetComponent<Rigidbody2D>())
            {
                collision.gameObject.AddComponent<Rigidbody2D>();
            }

            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.gameObject.transform.SetParent(GameSystem.instance.Panel_Box.transform);
            GameSystem.instance.boxList.Add(collision.gameObject.GetComponent<BoxComponent>());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BoxComponent>().isEnter = false;
        GameSystem.instance.boxList.Remove(collision.gameObject.GetComponent<BoxComponent>());
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
        }
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
