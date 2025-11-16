using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class ConditionalDialogue
    {
        public string requiredFlag;
        public DialogueLine[] dialogueLines;
    }

    Camera mainCamera;
    public GameObject actionIndicator;
    public GameObject dialogueCanvas;
    public GameObject dialogueBubble;

    [Header("Dialogue")]
    public DialogueLine[] defaultDialogue;
    public ConditionalDialogue[] conditionalDialogues;

    void Start()
    {
        actionIndicator.SetActive(false);
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(false);
        }
    }
    
    public void OnInteract()
    {
        DialogueLine[] dialogue = new DialogueLine[]
        {
            new DialogueLine { text = "Hi!", hasChoices = false },
            new DialogueLine { text = "Do you want to buy something?", hasChoices = true,
                choices = new DialogueChoice[]
                {
                    new DialogueChoice { choiceText = "Yes", nextLines = new DialogueLine[]
                        { new DialogueLine { text = "Great! Here's the shop." } } },
                    new DialogueChoice { choiceText = "No", nextLines = new DialogueLine[]
                        { new DialogueLine { text = "Okay, come back later!" } } }
                }
            }
        };

        DialogueManager.instance.StartDialogue(dialogue, this);
    }

    public void StartDialogueFromPlayer()
    {
        DialogueLine[] dialogue = GetDialogue();
        DialogueManager.instance.StartDialogue(dialogue, this);
        // Set flag after starting dialogue
        if (dialogue != null && dialogue.Length > 0)
        {
            DialogueFlags.instance.SetFlag(dialogue[0].text);
        }
    }

    private DialogueLine[] GetDialogue()
    {
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
