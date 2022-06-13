using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest2 : MonoBehaviour
{
    private Animator animator;
    public bool isMoving;
    public bool idle;
    private bool reachedPoint1;
    private bool reachedPoint2;
    public AudioSource guestarrivingAudioSource;
    public AudioSource guestWaitingAudioSource;
    private double MinDist = 0.05;
    public float runSpeed;
    public GameObject runPoint;
    public GameObject runPoint2;

    private Vector3 roomPos = new Vector3(0.0909f, 0.574f, 0.1377f);

    // Start is called before the first frame update
    void Start()
    {
        guestarrivingAudioSource = GameObject.FindWithTag("GuestArrivingAudioSource").GetComponent<AudioSource>();
        guestWaitingAudioSource = GameObject.FindWithTag("GuestWaitingAudioSource").GetComponent<AudioSource>();
        isMoving = true;
        reachedPoint1 = false;
        reachedPoint2 = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!reachedPoint1 && isMoving)
        {
            idle = false;
            animator.Play("Base Layer.Walk");
            moveGuest();
        }
        if(!reachedPoint2 && isMoving)
        {
            moveGuestForward();
        }

    }

    public void moveGuest()
    {
        if (Vector3.Distance(this.transform.position, runPoint.transform.position) >= MinDist)
        {
            transform.position += transform.right * runSpeed * Time.deltaTime;
        }
        else {
            GetComponent<BoxCollider2D>().enabled = true;
            reachedPoint1 = true;
        }  
    }

    public void moveGuestForward()
    {
        if (Vector3.Distance(this.transform.position, runPoint2.transform.position) >= MinDist)
        {
            transform.position -= transform.forward * runSpeed * Time.deltaTime;
        }
        else {
            GetComponent<BoxCollider2D>().enabled = true;
            reachedPoint2 = true;
            isMoving = false;
            gameObject.SetActive(false);
            placeGuestInRoom();
        }  
    }

    public void placeGuestInRoom()
    {
        gameObject.transform.position = roomPos;
        gameObject.SetActive(true);
    }
}
