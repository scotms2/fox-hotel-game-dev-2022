using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingScript : MonoBehaviour
{
    public LayerMask layer;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touchZero = Input.GetTouch(0);
            Vector3 p = Camera.main.ScreenToWorldPoint(touchZero.position);
            Ray ray = new Ray(p, transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast (ray, out hitInfo, layer))
            {
                //Debug.Log(hitInfo.transform.gameObject.GetComponent<Collider>().bounds.size);
                //Debug.Log("position: " + hitInfo.transform.position);
                transform.root.GetComponent<CameraScript>().currentRoomPos = new Vector3( hitInfo.transform.position.x, hitInfo.transform.position.y,0.4f);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            }
            else {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
            }
           
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray02 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray02, out hit, layer))
            {
                transform.root.GetComponent<CameraScript>().currentRoomPos = new Vector3(hit.transform.position.x, hit.transform.position.y, 0.4f);
                Debug.DrawLine(ray02.origin, hit.point, Color.red);
            }
        }
    }
}
