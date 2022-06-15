using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyFox2 : MonoBehaviour
{
    private Animator animator;
    public GameObject smallDialogueBox;
    public GameObject bigDialogueBox;
    public DialogueUI dialogueUI;
    public GameObject dialogueUI02;
    public bool runOnce;
    public Gold gold;
    public Transform GreyPlace;

    private Vector3 roomPos = new Vector3(-0.0249f, -0.347f, 0.0671f);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        runOnce = false;
        if (gold.currclient >= 4)
        {
            showBigDialogueBox();
            transform.position = GreyPlace.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("Base Layer.Idle");

    }

    public void showBigDialogueBox()
    {
        if (smallDialogueBox.activeSelf == false&&gold.currclient<4)
        {
            bigDialogueBox.SetActive(true);
            runOnce = true;
            gameObject.SetActive(false);
            placeGreyInOffice();
        }
    }

    public void placeGreyInOffice()
    {
        if (gold.currclient < 4)
            gameObject.transform.position = roomPos;
        gameObject.SetActive(true);
    }
    void OnMouseUp()
    {
        if (gold.currclient >= 4)
            dialogueUI02.SetActive(true);
    }
}
