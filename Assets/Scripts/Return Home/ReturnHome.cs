using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : MonoBehaviour
{
    public GameObject reception;

    public void Home()
    {
        Vector3 receptionPos = reception.transform.position;
        receptionPos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = receptionPos;
    }
}
