using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFox : MonoBehaviour
{
    public bool isMoving = true;
    private double MinDist = 0.04;
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
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //runPoint = GameObject.FindWithTag("Point1");
        reachedPoint1 = false;
        reachedPoint2 = false;
        reachedPoint3 = false;
        reachedPoint4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!reachedPoint1)
        {
            movePlayerToPoint1();
        }
        if(reachedPoint1 && !reachedPoint2)
        {
            if(dialogueUI.dialogueBoxClosed)
            {
                movePlayerToPoint2();
            }
        }
        if(reachedPoint2 && !reachedPoint3)
        {
            movePlayerToPoint3();
        }
        if(reachedPoint3 && !reachedPoint4)
        {
            spriteRenderer.flipX = true;
            movePlayerToPoint4();
        }
    }

    public void movePlayerToPoint1()
    {
        if (Vector3.Distance(this.transform.position, runPoint.transform.position) >= MinDist)
        {
            isMoving = true;
            transform.position -= transform.right * runSpeed * Time.deltaTime;
        }
        else {
            isMoving = false;
            reachedPoint1 = true;
        }
    }

    public void movePlayerToPoint2() 
    {
        if(Vector3.Distance(this.transform.position, runPoint2.transform.position) >= MinDist)
        {
            isMoving = true;
            transform.position += transform.forward * runSpeed * Time.deltaTime;
        }
        else{
            isMoving = false;
            reachedPoint2 = true;
        }
    }

    public void movePlayerToPoint3()
    {
        if (Vector3.Distance(this.transform.position, runPoint3.transform.position) >= MinDist)
        {
            isMoving = true;
            transform.position -= transform.right * runSpeed * Time.deltaTime;
        }
        else {
            isMoving = false;
            reachedPoint3 = true;
        }
    }

    public void movePlayerToPoint4()
    {
        if(Vector3.Distance(this.transform.position, runPoint4.transform.position) >= MinDist)
        {
            isMoving = true;
            transform.position -= transform.forward * runSpeed * Time.deltaTime;
        }
        else{
            isMoving = false;
            reachedPoint4 = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Point1")
        {
            isMoving = false;
            StartCoroutine(wait());
            dialogue.SetActive(true);
        }
    }

    private IEnumerator wait() {
        yield return new WaitForSeconds(1);
    }
}
