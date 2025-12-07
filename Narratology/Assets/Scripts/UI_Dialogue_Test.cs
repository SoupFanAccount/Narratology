using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Dialogue_Test : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public enum Speaker { Clerk, Player, Radio}
        public Speaker speaker;
        [TextArea] public string text;
    }


    [Header("UI")]
    public GameObject panel;
    public GameObject clerkPortrait;
    public GameObject playerPortrait;
    public GameObject radioPortrait;
    public TextMeshProUGUI dialogueText;

    private UI_Dialogue_Sequence currentSequence;
    private int index = 0;

    public UI_Dialogue_Trigger dialogueTrigger;

    public bool onGoingDialogue = false;
    public bool singleLineGoingOn = false;

    private void Update()
    {
        if (onGoingDialogue)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                NextLine();
            }
        }

    }

    public void StartDialogue(UI_Dialogue_Sequence sequence)
    {
        //dialogueTrigger.canBeTalkedTo = false; //Skift, så man ikke kan snakke med ham igen om det samme

        currentSequence = sequence;
        index = 0;
        panel.SetActive(true);
        ShowLine();
        onGoingDialogue = true;
    }

    public void NextLine()
    {
        index++;
        if (index >= currentSequence.lines.Length)
        {
            EndDialogue();
            return;
        }
        ShowLine();
    }

    void ShowLine()
    {
        DialogueLine line = currentSequence.lines[index];

        // Toggle speaker visibility
        bool radioSpeaking = line.speaker == DialogueLine.Speaker.Radio;
        if (radioSpeaking)
        {
            Debug.Log("Radio talking");
            radioPortrait.SetActive(true); //RADIO IS TALKING! SHhHH
            clerkPortrait.SetActive(false);
            playerPortrait.SetActive(false);
        }
        else
        {
            bool clerkSpeaking = line.speaker == DialogueLine.Speaker.Clerk;
            if (clerkSpeaking)
            {
                Debug.Log("Clerk is speaking");
                clerkPortrait.SetActive(true);
                playerPortrait.SetActive(false);
                radioPortrait.SetActive(false);
            }
            else
            {
                Debug.Log("Player is speaking");
                clerkPortrait.SetActive(false);
                playerPortrait.SetActive(true);
                radioPortrait.SetActive(false);
            }
        }

        dialogueText.text = line.text;
    }

    public void EndDialogue()
    {
        panel.SetActive(false);
        onGoingDialogue = false;
    }

}
