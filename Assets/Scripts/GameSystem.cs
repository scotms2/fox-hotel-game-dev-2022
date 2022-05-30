using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameSystem : MonoBehaviour
{
    public Gold gold;
    public static GameSystem instance;
    public Text Txt_Time;
    private int time = 60;
    public GameObject Obj_GameOver;
    public Text Txt_GameOver;
    public Button btnContinue;

    public bool flag = false;
    public bool down = false;

    public GameObject Panel_Box;
    public GameObject Panel_Left;
    public GameObject Panel_Right;
    public CabinetComponent CabinetComponent;
    public List<CabinetComponent> cabinets = new List<CabinetComponent>();
    public List<BoxComponent> boxList = new List<BoxComponent>();
    public List<BoxComponent> box11 = new List<BoxComponent>();
    public List<BoxComponent> box12 = new List<BoxComponent>();
    public List<BoxComponent> box22 = new List<BoxComponent>();
    public List<BoxComponent> box31 = new List<BoxComponent>();
    public AudioSource BGMiniAudioSource;
    public AudioSource gameLevelCompletedAudioSource;
    public AudioSource explosionPrizeAudioSource;
    public AudioSource BagplacedAudioSource;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        BGMiniAudioSource.Play();
        StartCoroutine(ChangeTime());
        RandomInstantiateRightBox();
        RandomInstantiateLeftBox();
        btnContinue.onClick.AddListener(delegate
        {
            explosionPrizeAudioSource.Play();
            StartCoroutine(WaitLoadScene(0));
            SceneManager.UnloadSceneAsync("NewMiniGame");
            SceneManager.LoadScene("Demo2-1");
        });
    }

    private IEnumerator ChangeTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            Txt_Time.text = "Time:" + time;
            if (Panel_Left.transform.childCount == 0)
            {
                flag = CabinetComponent.allChildGrid.TrueForAll(
                    x => x.GetComponent<BoxCompletedEvent>().isEnter == true);
                down = boxList.TrueForAll(
                    x => x.isDown == true);

                if (flag == true && down == true)
                {
                    StopCoroutine(ChangeTime());
                    gameLevelCompletedAudioSource.Play();
                    GameOver(100);
                    break;
                }
            }
        }
    }

    IEnumerator WaitLoadScene(int i)
    {
        yield return new WaitForSeconds(2f);
        if (i == 0)
            gold.score += 50;
        gold.IsDisPlayer = true;
        SceneManager.LoadScene("Demo2");
    }


    private void GameOver(int score)
    {
        Obj_GameOver.SetActive(true);
        Txt_GameOver.text = $"Minigame competed!You earned {score} coins!";
    }


    public void RandomInstantiateRightBox()
    {
        CabinetComponent a = Instantiate(cabinets[Random.Range(0, cabinets.Count)], Panel_Right.transform);
        CabinetComponent = a;
    }

    public void RandomInstantiateLeftBox()
    {
        for (int i = 0; i < CabinetComponent.boxId.Length; i++)
        {
            string[] names = CabinetComponent.boxId[i].Split(',');
            if (names[0] == "11")
            {
                InstantiateBox(int.Parse(names[1]), box11);
            }
            else if (names[0] == "12")
            {
                InstantiateBox(int.Parse(names[1]), box12);
            }
            else if (names[0] == "22")
            {
                InstantiateBox(int.Parse(names[1]), box22);
            }
            else
            {
                InstantiateBox(int.Parse(names[1]), box31);
            }
        }
    }

    void InstantiateBox(int num, List<BoxComponent> boxlist)
    {
        for (int i = 0; i < num; i++)
        {
            BoxComponent box = Instantiate(boxlist[Random.Range(0, boxlist.Count)], Panel_Left.transform);
        }
    }
}