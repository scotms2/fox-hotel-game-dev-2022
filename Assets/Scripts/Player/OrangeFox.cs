using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFox : MonoBehaviour
{
    public bool isMoving;
    //private double MinDist = 0.04;
    public GameObject runPoint;
    public GameObject runPoint2;
    public GameObject runPoint3;
    public GameObject runPoint4;
    public float runSpeed;
    public GameObject dialogue;

    public DialogueUI dialogueUI;

    private bool reachedPoint1;
    private bool reachedPoint2;
    public bool reachedPoint3;
    private bool reachedPoint4;
    private bool firstGuestCheck;
    public SpriteRenderer spriteRenderer;
    public Guest guest;
    public GameObject guestPath;
    private Animator animator;
    public TitleScreenButton titleScreenButton; 

    // Start is called before the first frame update
    void Start()
    {
        //runPoint = GameObject.FindWithTag("Point1");
        isMoving = true;
        reachedPoint1 = false;
        reachedPoint2 = false;
        reachedPoint3 = false;
        reachedPoint4 = false;
        firstGuestCheck = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(titleScreenButton.gameStart)
        {
            animator.Play("Base Layer.Red - Idle");
            if(!reachedPoint1 && isMoving)
            {
                movePlayerToPoint1();
            }
            if(reachedPoint1 && !reachedPoint2)
            {
                isMoving = true;
                if(dialogueUI.dialogueBoxClosed && isMoving)
                {
                    movePlayerToPoint2();
                }
            }
            if(reachedPoint2 && !reachedPoint3 && isMoving)
            {
                movePlayerToPoint3();
            }
            if(reachedPoint3 && !reachedPoint4 && isMoving)
            {
                spriteRenderer.flipX = true;
                movePlayerToPoint4();
            }
        }
    }

    public void movePlayerToPoint1()
    {
        transform.position -= transform.right * runSpeed * Time.deltaTime;
    }

    public void movePlayerToPoint2() 
    {
        transform.position += transform.forward * runSpeed * Time.deltaTime;
    }

    public void movePlayerToPoint3()
    {
        transform.position -= transform.right * runSpeed * Time.deltaTime;
    }

    public void movePlayerToPoint4()
    {
        transform.position -= transform.forward * runSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Point1")
        {
            isMoving = false;
            reachedPoint1 = true;
            StartCoroutine(wait());
            dialogue.SetActive(true);
        }

        if(other.gameObject.tag == "Point2")
        {
            reachedPoint2 = true;
        }

        if(other.gameObject.tag == "Point3")
        {
            reachedPoint3 = true;
        }

        if(other.gameObject.tag == "Point4")
        {
            isMoving = false;
            reachedPoint4 = true;
            if(!firstGuestCheck)
            {
                guestPath.SetActive(true);
                guest.gameObject.SetActive(true);
                firstGuestCheck = true;
            }
        }
    }

    private IEnumerator wait() {
        yield return new WaitForSeconds(1);
    }
}
