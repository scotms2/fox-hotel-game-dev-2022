using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Awake()
    {
        if (IsLevel2)
        {
            if (gold.currclient >= 3)
            {
                gold.currclient = 3;
            }
            else
            {
                StartCoroutine(WaitClient());
            }
            for (int i = 0; i < gold.currclient; i++)
            {
                Client[i].SetActive(true);
                Client[i].GetComponent<Guest2>().placeGuestInRoom();
            }
            Client[gold.currclient].SetActive(true);
            gold.currclient++;
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
}
