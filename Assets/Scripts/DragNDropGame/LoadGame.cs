using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private string NewMiniGame;
    [SerializeField] private string Tutorial;

    void OnMouseUp()
    {
        SceneManager.LoadScene(NewMiniGame);
        // Destroy(gameObject);
    }

    public void back()
    {
        SceneManager.LoadScene(NewMiniGame);
    }
}
