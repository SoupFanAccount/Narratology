using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class ConditionalDialogue
    {
        public string requiredFlag;
        public string[] dialogueLines;
    }

    Camera mainCamera;
    public GameObject actionIndicator;

    [Header("Dialogue")]
    public string[] defaultDialogue;
    public ConditionalDialogue[] conditionalDialogues;

    void Start()
    {
        actionIndicator.SetActive(false);
        mainCamera = Camera.main;
    }

    // This shows the indicator
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(true);
        }
    }

    // This hides the indicator
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(false);
        }
    }

    
    public void StartDialogueFromPlayer()
    {
        string[] dialogue = GetDialogue();
        DialogueManager.instance.StartDialogue(dialogue, this);
    }

    private string[] GetDialogue()
    {
        // Check conditional dialogues in reverse order (latest conditions first)
        if (conditionalDialogues != null)
        {
            for (int i = conditionalDialogues.Length - 1; i >= 0; i--)
            {
                if (DialogueFlags.instance != null && 
                    DialogueFlags.instance.HasFlag(conditionalDialogues[i].requiredFlag))
                {
                    return conditionalDialogues[i].dialogueLines;
                }
            }
        }

        return defaultDialogue;
    }

    // Hide the indicator when dialogue starts.
    private void OnDisable()
    {
        actionIndicator.SetActive(false);
    }

    void LateUpdate()
    {
        if (actionIndicator.activeInHierarchy)
        {
            actionIndicator.transform.rotation = mainCamera.transform.rotation;
        }
    }
}