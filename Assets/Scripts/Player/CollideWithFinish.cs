using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithFinish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject);
        if(other.collider.tag == "OrangeFox")
        {
            Debug.Log("Fox collided with the reception desk");
        }
    }
}
