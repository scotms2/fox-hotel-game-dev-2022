using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    // Update is called once per frame
    void Update()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 mousePos = Input.mousePosition;

        Camera.main.transform.position += Camera.main.transform.forward * ScrollWheel;
    }
}
