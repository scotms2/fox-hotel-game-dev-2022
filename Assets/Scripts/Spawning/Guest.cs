using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guest : MonoBehaviour
{
    private Spawner guestSpawner;

    public float runSpeed;

    public GameObject runPoint;
    //public GameObject runPoint2;

    //private double MinDist = 0.05;

    public bool isMoving;
    public bool idle;
    private bool reachedPoint1;
    private Animator animator;

    public GameObject partOneDialogue;
    public AudioSource guestarrivingAudioSource;
    public AudioSource guestWaitingAudioSource;
    public string scenename;

    // Start is called before the first frame update
    void Start()
    {
        guestarrivingAudioSource = GameObject.FindWithTag("GuestArrivingAudioSource").GetComponent<AudioSource>();
        guestWaitingAudioSource = GameObject.FindWithTag("GuestWaitingAudioSource").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        isMoving = true;
        reachedPoint1 = false;
        idle = false;
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
        else{
            animator.Play("Base Layer.Idle");
            idle = true;
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
            //Debug.Log("Hit Guest Point 1");
            isMoving = false;
            reachedPoint1 = true;
            partOneDialogue.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Loading New Scene..");
        SceneManager.LoadScene(scenename);
    }
}
