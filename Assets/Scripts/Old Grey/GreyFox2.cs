using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyFox2 : MonoBehaviour
{
    private Animator animator;
    public GameObject smallDialogueBox;
    public GameObject bigDialogueBox;
    public DialogueUI dialogueUI;
    public bool runOnce;

    private Vector3 roomPos = new Vector3(-0.0249f, -0.347f, 0.0671f);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        runOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("Base Layer.Idle");
        if(runOnce == false)
        {
            showBigDialogueBox();     
        }
    }

    public void showBigDialogueBox()
    {
        if(smallDialogueBox.activeSelf == false)
        {
            bigDialogueBox.SetActive(true);
            runOnce = true;
            gameObject.SetActive(false);
            placeGreyInOffice();
        }
    }

    public void placeGreyInOffice()
    {
        gameObject.transform.position = roomPos;
        gameObject.SetActive(true);
    }
}
