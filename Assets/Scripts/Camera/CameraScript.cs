using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public Vector3 camOutPos;

    public Vector3 camInPos;

    // Update is called once per frame
    void Update()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        Camera.main.transform.position += Camera.main.transform.forward * ScrollWheel;

        if(this.transform.position.z < -18)
        {
            this.transform.position = camOutPos;
        }

        if(this.transform.position.z > -6.5)
        {
            this.transform.position = camInPos;
        }
    }
}
