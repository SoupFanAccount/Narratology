using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] UI_Dialogue_Test dialogueManager;
    public UI_Dialogue_Sequence sequence;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.item1Collected = true;
                dialogueManager.StartDialogue(sequence);
                Destroy(gameObject);
            }
        }        
    }
}
