using UnityEngine;

public class PlayDialogueOnTouch : MonoBehaviour
{
    [SerializeField] UI_Dialogue_Test dialogueManager;
    public UI_Dialogue_Sequence sequence;

    private void OnTriggerEnter(Collider other)
    {
        dialogueManager.StartDialogue(sequence);
        Destroy(gameObject);
    }
}
