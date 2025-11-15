using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Script References")]
    public Interactable interactable;
    public DialogueController dialogueController; 

    [Header("Dialogue State")]
    private string[] currentDialogueLines;
    private int currentLineIndex = 0;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (dialogueController != null)
        {
            dialogueController.enabled = false;
        }
    }

    public void StartDialogue(string[] lines, Interactable npc)
    {
        interactable = npc; 
        interactable.enabled = false; 
        dialogueController.enabled = true; 
        currentDialogueLines = lines;
        currentLineIndex = 0;
        dialogueController.StartNewLine(currentDialogueLines[currentLineIndex]);
    }

    public void AdvanceDialogue()
    {
        currentLineIndex++; 

        if (currentLineIndex < currentDialogueLines.Length)
        {
            dialogueController.StartNewLine(currentDialogueLines[currentLineIndex]);
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueController.enabled = false; 
        interactable.enabled = true; 
        currentDialogueLines = null;
        interactable = null;
    }
    
    public bool IsDialogueActive()
    {
        if (dialogueController == null)
        {
            return false;
        }
    
        // The dialogue is active if the dialogueController script is enabled
        return dialogueController.enabled;
    }
} 