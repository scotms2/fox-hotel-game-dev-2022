using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    private Spawner guestSpawner;

    public float runSpeed;

    public GameObject runPoint;

    private double MinDist = 0.05;

    public bool isMoving = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        runPoint = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        moveGuest();

        if(isMoving == false)
        {
            animator.gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        guestSpawner = spawner;
    }

    public void moveGuest()
    {
        if (Vector3.Distance(this.transform.position, runPoint.transform.position) >= MinDist)
        {
            transform.position -= transform.right * runSpeed * Time.deltaTime;
        }
        else {
            GetComponent<BoxCollider2D>().enabled = true;
            isMoving = false;
        }
    }
}
