using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int Golds;
    public float deltaTime = 0;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        Golds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        increaceGold();
    }

    private void increaceGold()
    {
        deltaTime += Time.deltaTime;
        timer = (int)deltaTime;
        Golds = timer * 5;
    }
}
