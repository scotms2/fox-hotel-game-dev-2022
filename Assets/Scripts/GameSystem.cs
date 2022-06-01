using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Gold Gold;
    public static GameSystem instance;
    public List<BoxComponent> boxs = new List<BoxComponent>();
    public Text Txt_Time;
    private int time = 60;
    public GameObject Obj_GameOver;
    public Text Txt_GameOver;
    public bool flag = false;

    public GameObject Panel_Box;
    public GameObject Panel_Left;
    public GameObject Panel_Right;
    public CabinetComponent CabinetComponent;
    public List<CabinetComponent> cabinets = new List<CabinetComponent>();
    public List<BoxComponent> boxList = new List<BoxComponent>();

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(ChangeTime());

        RandomInstantiateLeftBox();
        RandomInstantiateRightBox();
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
                flag = boxList.TrueForAll(x => x.isChangePos == false);
                if (flag == true)
                {
                    WaitTimeManager.WaitTime(2, delegate
                    {
                        StopCoroutine(ChangeTime());
                        GameOver("Successful");
                        StartCoroutine(WaitLoadScene(0));
                    });
                }
            }
        }
        GameOver("GameOver!!!");
        StartCoroutine(WaitLoadScene(1));
    }

    IEnumerator WaitLoadScene(int i)
    {
        yield return new WaitForSeconds(2f);
        if (i == 0)
            Gold.score += 50;
        Gold.IsDisPlayer = true;
        SceneManager.LoadScene("Demo2");
    }


    private void GameOver(string str)
    {
        Obj_GameOver.SetActive(true);
        Txt_GameOver.text = str;
    }




    public void RandomInstantiateRightBox()
    {
        CabinetComponent a = Instantiate(cabinets[Random.Range(0, cabinets.Count)], Panel_Right.transform);
        CabinetComponent = a;
    }
    public void RandomInstantiateLeftBox()
    {
        for (int i = 0; i < 2; i++)
        {
            BoxComponent a = Instantiate(boxs[Random.Range(0, boxs.Count)], Panel_Left.transform);
            if (a.gameObject.GetComponent<Rigidbody2D>())
            {
                Destroy(a.gameObject.GetComponent<Rigidbody2D>());
            }
        }
    }
}
