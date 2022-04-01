using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Spawner foxSpawner;

    public float runSpeed;

    public GameObject runPoint;

    public GameObject runPoint2;

    private double MinDist = 0.5;

    // Start is called before the first frame update
    void Start()
    {
        runPoint = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        //if(foxSpawner.paused == false)
        //{
            moveFox();
        //}
    }

    public void SetSpawner(Spawner spawner)
    {
        foxSpawner = spawner;
    }

    public void moveFox()
    {
        if (Vector3.Distance(transform.position, runPoint.transform.position) >= MinDist)
        {
            transform.position += transform.right * runSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Collided with reception");
        //StartCoroutine(wait());
    }

    // IEnumerator wait()
    // {
    //     foxSpawner.paused = true;
    //     Debug.Log("Waiting....");
    //     yield return new WaitForSeconds(10);
    //     foxSpawner.paused = false;
    //     Debug.Log("Done Waiting!");
    // }
}
