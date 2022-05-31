using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyFox : MonoBehaviour
{
    public GameObject runPoint;
    private double MinDist = 0.05;
    public bool isMoving = false;
    public float runSpeed;
    private bool reachedPoint1;
    public OrangeFox orangeFox;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        reachedPoint1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(orangeFox.reachedPoint3 && !reachedPoint1)
        {
            spriteRenderer.flipX = true;
            moveGreyFox();
        }
    }

    public void moveGreyFox()
    {
        if (Vector3.Distance(this.transform.position, runPoint.transform.position) >= MinDist)
        {
            isMoving = true;
            transform.position += transform.right * runSpeed * Time.deltaTime;
        }
        else {
            isMoving = false;
            reachedPoint1 = true;
            spriteRenderer.flipX = false;
        }
    }
}
