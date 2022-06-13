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
    private double MinDist = 0.05;


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
        if (Vector3.Distance(this.transform.position, runPoint.transform.position) >= MinDist)
        {
            transform.position -= transform.right * runSpeed * Time.deltaTime;
        }
        else {
            GetComponent<BoxCollider2D>().enabled = true;
            isMoving = false;
            reachedPoint1 = true;
            partOneDialogue.SetActive(true);
        }    
    }

    // void OnTriggerEnter2D (Collider2D other) {
       
        
    //         Debug.Log("Hit Guest Point 1");
    //         isMoving = false;
    //         reachedPoint1 = true;
    //         partOneDialogue.SetActive(true);
        
    // }

    void OnMouseUp()
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);    
    }
}   
