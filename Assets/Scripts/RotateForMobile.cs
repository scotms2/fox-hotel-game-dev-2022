using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForMobile : MonoBehaviour
{
    public GameObject panelLeft;

    void Start() {
    }

    public void rotate()
    {
        foreach(Transform child in panelLeft.transform)
        {
            child.Rotate(0, 0, this.transform.rotation.z - 90);
        }
        //transform.Rotate(0, 0, this.transform.rotation.z - 90);
    }
}
