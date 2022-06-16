using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private string miniGameScene;
    [SerializeField] private string mainDemoScene;

    void OnMouseUp()
    {
        SceneManager.LoadScene(miniGameScene);
        // Destroy(gameObject);
    }

    public void back()
    {
        SceneManager.LoadScene(mainDemoScene);
    }
}
