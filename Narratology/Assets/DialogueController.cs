using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI DialogueText;
    public Animator DialgoueAnimator;
    public GameObject dialogueBox; // Needed to show/hide the UI

    [Header("Settings")]
    public float DialogueSpeed;

    private Coroutine writingCoroutine; // To keep track of your coroutine
    
    // This is the public method the DialogueManager calls.
    public void StartNewLine(string sentence)
    {
        // If we were already writing, stop it
        if (writingCoroutine != null)
        {
            StopCoroutine(writingCoroutine);
        }

        // --- THIS IS THE FIX ---
        // The "if (Index <= ...)" check is removed.
        
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

    // --- UI Control Methods ---

    // Called by the DialogueManager when it sets 'enabled = true'
    void OnEnable()
    {
        // When the manager enables me, show my UI.
        dialogueBox.SetActive(true);
        
        /*
        if (DialgoueAnimator != null)
        {
            //DialgoueAnimator.SetTrigger("Open");
        }
        */
    }

    // Called by the DialogueManager when it sets 'enabled = false'
    void OnDisable()
    {
        // When the manager disables me, hide my UI.
        dialogueBox.SetActive(false);
        
        // Also, stop any typing
        if (writingCoroutine != null)
        {
            StopCoroutine(writingCoroutine);
            writingCoroutine = null;
        }
    }
}