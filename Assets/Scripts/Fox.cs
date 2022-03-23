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
        if (Vector3.Distance(transform.position, runPoint.transform.position) >= MinDist)
        {
            transform.position += transform.right * runSpeed * Time.deltaTime;
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        foxSpawner = spawner;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }
}
