using UnityEngine;

public class WhereAreWe : MonoBehaviour
{
    public int gameState = 0;
    public PlayerScript player;

    [SerializeField] InteractCollidersController colliderController;

    public UI_Dialogue_Sequence[] internalDialogues;

   [SerializeField] UI_Dialogue_Trigger dialogueTrigger;
    [SerializeField] UI_Dialogue_Test dialogueManager;

    public GameObject[] gameStateTriggers;
    public int gameStateTriggerCounter = 0;

    [SerializeField] GameObject mysteryDoor, mysteryDoorLocked;

    void Awake()
    {

    }

    private void Start()
    {
        //TEST! Den her skal køres når bilen er stoppet :)
        //CheckGameStateAndDoStuff(1);

        mysteryDoor.SetActive(false);
        mysteryDoorLocked.SetActive(true);
    }

    void AdvanceGameState(int advanceStep)
    {
        gameState += advanceStep;
    }

    void NewGameStateTrigger()
    {
        gameStateTriggers[gameStateTriggerCounter].SetActive(true);
        gameStateTriggerCounter++;
    }

    void GoToNextClerkDialogue()
    {
        dialogueTrigger.whichSequence++;
    }

    public void CheckGameStateAndDoStuff(int advanceNumber)
    {
        switch (gameState)
        {
            case 0: //Dude er lige stået ud af bilen og skal have noget benzin
                dialogueManager.StartDialogue(internalDialogues[0]);
                Debug.Log("Game Start");

                //Turn on the first gameStateTrigger - Clerk talk first time
                NewGameStateTrigger();

                //Her kan man også starte den første dialog med Clerk, når man går indenfor

                break;

            case 1: //Når man går hen for at tale med Clerk først

                //Gaspump ACTIVE
                Debug.Log("Gaspump ACTIVE");
                colliderController.gasPumpCollider.SetActive(true);
                break;

            case 2: //Interact with Gas pump, but no receipt
                //Play voice line: "Where's the receipt...?"
                dialogueManager.StartDialogue(internalDialogues[1]);

                //Go to next clerk dialouge - "uhh, I paid for some gas"
                GoToNextClerkDialogue();

                //Turn on gameStateTrigger that makes gas pump work again
                NewGameStateTrigger();

                break;   

            case 3: //Walk in to talk to the clerk again to get TRUE GAS
                //Trigger 2 leads to here

                colliderController.goodGasPumpCollider.SetActive(true);
                Debug.Log("True gas is active");



                //If player walks into the mysterious room (not bathroom){
                //   The player can pick up an object (then play voice line: "huh, an [ITEM]" 
                //}   ---ITEM GET 1/2---
                break;

            case 4: //Pump gas into car, SUCCESFULY
                //Play voice line: "At least it pumps now"
                dialogueManager.StartDialogue(internalDialogues[2]);
                

                //Turn on collider for taking car!!!

                break;

            case 5: //Get into car and drive away
                    //PLAY CAR CUTSCENE 1
                    //Play sounds:
                    //Internal monologue: "Must be because im tired"
                    //*Sees gas station again*, "Did I drive in circles?" *parks at station*
                    //Radio plays: "*inaudible* - seven people - *inaudible* - missing"
                break;

            case 6: //Arrive at gas station AGAIN
                //Play voice line: "I could use a bathroom. I'll go ask inside"


                //END THE GAME HERE!!! ----------------------------------------------------------------------------
                break;

            case 7: //Talk with the clerk
                //Play dialogue: "Heyy", "Do you have pest poom?" "Yes, behind buliding"
                break;

            case 8: //
                break;

            default:
                Debug.Log("Noget gik galt! Ingen gameState??????");
                break;
        }

        AdvanceGameState(advanceNumber);
    }
}
