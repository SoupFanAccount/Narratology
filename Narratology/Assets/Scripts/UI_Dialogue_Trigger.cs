using UnityEngine;

public class UI_Dialogue_Trigger : MonoBehaviour
{
    [SerializeField] GameObject interactE;
    InteractableShowE eScript;

    public UI_Dialogue_Sequence[] sequence;
    public UI_Dialogue_Test manager;

    public int whichSequence = 0;

    bool playerIsNear = false;

    public bool canBeTalkedTo = true; //Til at kontrollere game states og hvornår der bliver sagt de forskellige ting

    private void Awake()
    {
        eScript = interactE.GetComponent<InteractableShowE>();
    }

    private void Update()
    {
        if (playerIsNear && canBeTalkedTo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!manager.onGoingDialogue)
                {
                    manager.StartDialogue(sequence[whichSequence]);

                    //Turn off the E
                    eScript.TurnOffandMakeInteractable();
                }
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            manager.EndDialogue();
            eScript.TurnOffandMakeInteractable();
        }
    }
}
