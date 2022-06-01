using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    private Spawner guestSpawner;

    public float runSpeed;

    public GameObject runPoint;
    //public GameObject runPoint2;

    private double MinDist = 0.05;

    public bool isMoving;

    private Animator animator;

    public GameObject partOneDialogue;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            animator.Play("Base Layer.Walk");
            moveGuest();
        }
        else{
            animator.Play("Base Layer.Idle");
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        guestSpawner = spawner;
    }

    public void moveGuest()
    {
        transform.position -= transform.right * runSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "GuestPoint1")
        {
            Debug.Log("Hit Guest Point 1");
            isMoving = false;
            partOneDialogue.SetActive(true);
        }
    }
}
