using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float dragSpeed;
    private Vector3 dragOrigin;

    public Vector3 camOutPos;

    public Vector3 camInPos;

    private Vector3 oldPos;

    // Update is called once per frame
    void Update()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollWheel < 0)
        {
            //this.transform.position = camOutPos;
            Camera.main.orthographic = false;
        }
        else if (ScrollWheel > 0)
        {
            //this.transform.position = camInPos;
            Camera.main.orthographic = true;
        }

        // Camera.main.transform.position += Camera.main.transform.forward * ScrollWheel;

        // if(this.transform.position.z < camOutPos.z)
        // {
        //     this.transform.position = camOutPos;
        // }

        // if(this.transform.position.z > -6.5)
        // {
        //     this.transform.position = camInPos;
        // }

        if(Input.GetMouseButtonDown(0))
         {
            oldPos = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
         }
 
         if(Input.GetMouseButton(0))
         {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;
            transform.position = oldPos + -pos * dragSpeed;
         }
    }
}
