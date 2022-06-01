using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float speed = 50f;

    public Coroutine Run(string textToType, TextMeshProUGUI textLabel) {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TextMeshProUGUI textLabel)
    {
        textLabel.text = string.Empty;
        
        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length) 
        {
            t += Time.deltaTime * speed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
