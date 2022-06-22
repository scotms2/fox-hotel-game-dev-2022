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

    public Vector3 currentRoomPos;
    public GameObject wait_Image;

    private Vector3 oldPosition1;
    private Vector3 oldPosition2;
    private bool IsInput;
    private void Start()
    {
        currentRoomPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        A();
        //For zooming out (Pinch and Pull)
        //if (Input.touchCount == 2)
        //{
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    float difference = currentMagnitude - prevMagnitude;

        //    if (difference < 0)
        //    {
        //        Camera.main.orthographic = true;
        //        Camera.main.transform.position = camOutPos;
        //        ZoomOut = true;
        //    }
        //    else if(difference>0)
        //    {
        //        Camera.main.orthographic = false;
        //        currentRoomPos.z = Camera.main.transform.position.z;
        //        Camera.main.transform.position = currentRoomPos;
        //        ZoomOut = false;
        //    }
        //}
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollWheel < 0)
        {
            Camera.main.orthographic = true;
            Camera.main.transform.position = camOutPos;
            ZoomOut = true;
            //wait_Image.SetActive(false);
        }
        else if (ScrollWheel > 0)
        {
            Camera.main.orthographic = false;
            //currentRoomPos.z = Camera.main.transform.position.z;
            Camera.main.transform.position = currentRoomPos;
            ZoomOut = false;
            //wait_Image.SetActive(true);
        }

        //For Zooming in (tapping)
        if (Input.touchCount == 1)
        {
            if (ZoomOut)
            {
                Camera.main.orthographic = false;
                currentRoomPos.z = Camera.main.transform.position.z;
                Camera.main.transform.position = currentRoomPos;
                ZoomOut = false;
            }
        }

    }
    private void A()
    {
        if (Input.touchCount == 2 && !IsInput)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
            {
                oldPosition1 = Input.GetTouch(0).position;
                oldPosition2 = Input.GetTouch(1).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position;

                float currentTouchDistance = Vector3.Distance(tempPosition1, tempPosition2);
                float lastTouchDistance = Vector3.Distance(oldPosition1, oldPosition2);

                float distance = (currentTouchDistance - lastTouchDistance) * 0.2f * Time.deltaTime;

                if (distance < 0 && !ZoomOut)
                {
                    Camera.main.orthographic = true;
                    Camera.main.orthographicSize = 1f;
                    //Camera.main.transform.position = camOutPos;
                    ZoomOut = true;
                    IsInput = true;
                }
                if (distance > 0 && ZoomOut)
                {
                    Camera.main.orthographic = false;
                    //currentRoomPos.z = Camera.main.transform.position.z;
                    Camera.main.transform.position = currentRoomPos;
                    ZoomOut = false;
                    IsInput = true;
                }
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
        }
        else
        {
            IsInput = false;
        }
    }
}
