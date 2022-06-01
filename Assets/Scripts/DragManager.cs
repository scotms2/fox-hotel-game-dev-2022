using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragManager : MonoBehaviour
{

    public GameObject[] picObjects;

    public float timer = 10;

    public Text timerText;

    public GameObject[] GameOver;

    public int number=0;

    public GameObject dragGame;
    public void OnEnable()
    {
        number = 0;
        timer = 10;

        GameOver[0].SetActive(false);
        GameOver[1].SetActive(false);
        dragGame= GameObject.Instantiate(picObjects[Random.Range(0, picObjects.Length)], this.transform.GetChild(0));

       
    }

    public void OnDisable()
    {
        Destroy(dragGame);
    }
    // Update is called once per frame
    void Update()
    {
        if (number == 2) {

            GameOver[1].SetActive(true);
            return;
        }


        timer -= Time.deltaTime;
        if (timer < 0) {

            timer = 0;
            GameOver[0].SetActive(true);
        }
        timerText.text = timer.ToString("f2");
    }
}
