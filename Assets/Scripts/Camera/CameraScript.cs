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

    // Update is called once per frame
    void Update()
    {
        //For zooming out (Pinch and Pull)
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            if (difference < 0)
            {
                Camera.main.orthographic = true;
                Camera.main.transform.position = camOutPos;
                ZoomOut = true;
            }
        }

        //For Zooming in (tapping)
        if(Input.touchCount == 1){
            if(ZoomOut)
            {
                Camera.main.orthographic = false;
                currentRoomPos.z = Camera.main.transform.position.z;
                Camera.main.transform.position = currentRoomPos;
                ZoomOut = false;
            }
        }
    }
}
