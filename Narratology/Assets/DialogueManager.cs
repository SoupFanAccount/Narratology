using System.Threading;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Script References")]
    public MakePlayerTalk playerTalk;
    public WhereAreWe whereAreWe;
    public Interactable interactable;
    public DialogueController dialogueController; 

    [Header("Dialogue State")]
    private string[] currentDialogueLines;
    private int currentLineIndex = 0;

    public static DialogueManager instance;

    public string firstElement;
    public string lastElement;
    public string dialogueAsFlag;

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

    public void StartDialogue(string[] lines, Interactable interactableObject)
    {
        interactable = interactableObject; 
        interactable.enabled = false; 
        dialogueController.enabled = true; 
        currentDialogueLines = lines;
        currentLineIndex = 0;
        dialogueController.StartNewLine(currentDialogueLines[currentLineIndex]);
    }

    public void AdvanceDialogue()
    {
        if (playerTalk.imTalking == false)
        {
            currentLineIndex++;

            if (currentLineIndex < currentDialogueLines.Length)
            {
                dialogueController.StartNewLine(currentDialogueLines[currentLineIndex]);
            }
            else
            {
                firstElement = currentDialogueLines[0];
                //lastElement = currentDialogueLines[currentDialogueLines.Length - 1];
                //dialogueAsFlag = firstElement + lastElement;
                DialogueFlags.instance.SetFlag(firstElement);
                EndDialogue();

            }
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Ended dialogue");
        if (playerTalk.talkingTokens > 0)
        {
            playerTalk.imTalking = true;
            if(playerTalk.talkingTokens > 1)
            {
                whereAreWe.CheckGameStateAndDoStuff(0);
            }
            else
            {
                whereAreWe.CheckGameStateAndDoStuff(1);
            }
        }

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