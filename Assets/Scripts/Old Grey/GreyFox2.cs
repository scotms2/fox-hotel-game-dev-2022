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
    private bool isDown;
    private Vector3 roomPos = new Vector3(-0.0249f, -0.347f, 0.0671f);
    public Guest Guest;
    // Start is called before the first frame update
    void Start()
    {
        isDown = gold.IsDown;
        animator = GetComponent<Animator>();
        runOnce = false;
        if (!isDown)
        {
            if (GameObject.Find("GameSettings").GetComponent<GameSettings>().firstTime)
            {
                smallDialogueBox.SetActive(true);
            }
            else
            {
                runOnce = true;
            }
        }
        if (isDown)
        {
            Guest.isMoving = true;
            transform.position = GreyPlace.position;
            runOnce = true;
            GameObject.Find("GameSettings").GetComponent<GameSettings>().firstTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("Base Layer.Idle");
        if (!gold.IsDown)
            if (smallDialogueBox.activeSelf == false && gold.currclient < 4 && runOnce == false)
            {
                showBigDialogueBox();
                transform.position = GreyPlace.position;
            }
    }

    public void showBigDialogueBox()
    {
        bigDialogueBox.SetActive(true);
        runOnce = true;
        gameObject.SetActive(false);
        placeGreyInOffice();
        gold.IsDown = true;
    }

    public void placeGreyInOffice()
    {
        gameObject.transform.position = roomPos;
        gameObject.SetActive(true);
    }

    void OnMouseUp()
    {
        if (gold.currclient >= 4)
            dialogueUI02.SetActive(true);
        Debug.Log("ÒÑ¾­µã»÷");
    }

    public void DownGreyFox()
    {
        isDown = true;
    }
}
