using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject Panel_Start;
    public Button btn_start;
    public AudioSource startAudioSource;
    public Gold gold;
    public AudioSource bgAudioSource;
    public GameObject[] Client;
    public GameObject ClientFoward;
    [SerializeField]private bool IsLevel2;
    public GreyFox2 GreyFox;
    public GameObject Duihua;
    public GameObject[] m_Camera;
    private void Awake()
    {
        if (IsLevel2)
        {
            gold.currclient++;
            if (gold.currclient >1)
            {
                Duihua.SetActive(false);
                //GreyFox.enabled = false;
            }
            if (gold.currclient >= 4)
            {
                m_Camera[0].SetActive(false);
                m_Camera[1].SetActive(true);

                gold.currclient = 4;
            }
            else
            {
                StartCoroutine(WaitClient());
            }
            for (int i = 0; i < gold.currclient-1; i++)
            {
                Client[i].SetActive(true);
                Client[i].GetComponent<Guest2>().placeGuestInRoom();
            }
            Client[gold.currclient-1].SetActive(true);
        }
        gameManager = this;
    }

    void Start()
    {
        if (Panel_Start != null)
        {
            btn_start.onClick.AddListener(delegate
            {
                startAudioSource.Play();
                Panel_Start.SetActive(false);
                bgAudioSource.Play();
            });
        }
    }

    IEnumerator WaitClient()
    {
        yield return new WaitForSeconds(2f);
        ClientFoward.SetActive(true);
    }

    public void LoadScene(string name) 
    {
        SceneManager.LoadScene(name);
    }
}
