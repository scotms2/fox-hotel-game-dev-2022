using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public int CountdownNumber;
    private int temp;
    public float deltaTime = 0;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        temp = 100;
    
    }

    // Update is called once per frame
    void Update()
    {
        decreaceNumber();
        
    }

    private void decreaceNumber()
    {
        deltaTime += Time.deltaTime;
        timer = (int)deltaTime;
        CountdownNumber = temp - timer * 2 ;
        if (CountdownNumber <= 0)
        {
            CountdownNumber = 0;
        }

    }
}
