using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    //[SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI textLabel;
    [SerializeField] private DialogueObject IntroDialogue;

    private TypewriterEffect typewriterEffect;

    public bool dialogueBoxClosed;
    
    private void Start() {
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

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        gameObject.SetActive(false);
        dialogueBoxClosed = true;
        textLabel.text = string.Empty;
    }
}
