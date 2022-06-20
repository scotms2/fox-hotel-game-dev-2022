using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;
    //[SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI textLabel;
    [SerializeField] private DialogueObject IntroDialogue;

    private TypewriterEffect typewriterEffect;

    public bool dialogueBoxClosed;
    public string Scenename;
    public bool IsNextScene;
    public Guest guest;
    private int count;

    public void Awake()
    {
        Instance = this;
    }

    private void Start() {
        count = 0;
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(IntroDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject) 
    {
        gameObject.SetActive(true);
        dialogueBoxClosed = false;
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject) 
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        if (IsNextScene)
            SceneManager.LoadScene(Scenename);
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        count++;
        gameObject.SetActive(false);
        dialogueBoxClosed = true;
        textLabel.text = string.Empty;

        if(count == 2 && guest != null && !guest.reachedPoint1 && !guest.isMoving)
        {
            guest.isMoving = true;
            GameObject.Find("GameSettings").GetComponent<GameSettings>().firstTime = false;
        }
    }
}
