using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomUpdrade : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    // Start is called before the first frame update

    public void upgrade()
    {
        room1.SetActive(false);

        room2.SetActive(true);
    }
}
