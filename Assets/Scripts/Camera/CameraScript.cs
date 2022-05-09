using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{
    public float dragSpeed;

    public Vector3 camOutPos;

    public Vector3 camInPos;

    private Vector3 touchStart;

    private bool ZoomOut;

    public TextMeshProUGUI txt;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollWheel < 0)
        {
            Camera.main.orthographic = true;
            ZoomOut = true;
        }
        else if (ScrollWheel > 0)
        {
            Camera.main.orthographic = false;
            ZoomOut = false;
        }

        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            txt.text = "Difference Value: " + difference.ToString();

            if (difference < 0)
            {
                Camera.main.orthographic = true;
                ZoomOut = true;
            }
            else if (difference > 0)
            {
                Camera.main.orthographic = false;
                ZoomOut = false;
            }
        }

        if(Camera.main.orthographic)
        {
            if(Input.GetMouseButtonDown(0))
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
    
            if(Input.GetMouseButton(0))
            {
                Vector3 pos = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += pos;
            }
        }

        if(Physics.Raycast (ray, out hitInfo))
        {
            Debug.Log(hitInfo.transform.tag);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}
