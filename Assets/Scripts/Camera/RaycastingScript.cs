using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast (ray, out hitInfo))
        {
            Debug.Log(hitInfo.transform.gameObject.GetComponent<Collider>().bounds.size);
            Debug.Log("position: " + hitInfo.transform.position);
            transform.root.GetComponent<CameraScript>().currentRoomPos = hitInfo.transform.position;
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}
