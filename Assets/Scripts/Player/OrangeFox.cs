using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFox : MonoBehaviour
{
    public bool isMoving = true;
    private double MinDist = 0.04;
    public GameObject runPoint;
    public float runSpeed;
    public GameObject dialogue;

    //public DialogueUI dialogueUI;

    //private bool dialogueShow = false;

    // Start is called before the first frame update
    void Start()
    {
        runPoint = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
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

    private void OnTriggerEnter(Collider col) {
        Debug.Log(col.gameObject);
    }
}
