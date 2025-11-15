using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MakePlayerTalk : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI DialogueText;
    public GameObject dialogueBox; // Needed to show/hide the UI

    [Header("Settings")]
    public float DialogueSpeed;

    private Coroutine writingCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewLine(string sentence)
    {
        // If we were already writing, stop it
        if (writingCoroutine != null)
        {
            StopCoroutine(writingCoroutine);
        }


        DialogueText.text = "";
        // We pass the 'sentence' parameter here
        writingCoroutine = StartCoroutine(WriteSentence(sentence));
    }

    // This coroutine types out the sentence
    IEnumerator WriteSentence(string sentence)
    {
        foreach (char Character in sentence.ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        // Coroutine is finished
        writingCoroutine = null;
    }

}
