using UnityEngine;

public class EnterCar : MonoBehaviour
{
    public SpeedCheck car;

    bool playerInside = false;

    [SerializeField] UI_Dialogue_Test dialogueManager;
    [SerializeField] UI_Dialogue_Sequence sequence;
    public bool canTakeCar = false;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("stimkyy");
        if(other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInside)
            {
                if (canTakeCar)
                {
                    car.EnterCar();
                }
                else
                {
                    //Player says, I need to put gas on!
                    dialogueManager.StartDialogue(sequence);
                }

            }
        }
    }
}