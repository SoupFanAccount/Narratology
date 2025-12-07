using UnityEngine;

public class PlayDialogueAndDestroy : MonoBehaviour
{
    [SerializeField] UI_Dialogue_Test dialogueManager;
    public UI_Dialogue_Sequence sequence;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.StartDialogue(sequence);
        }
    }
}
