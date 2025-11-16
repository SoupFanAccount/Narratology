using UnityEngine;

public class WhereAreWe : MonoBehaviour
{
    public int gameState = 0;
    PlayerScript player;
    MakePlayerTalk playerTalk;

    void Start()
    {
        player = GetComponent<PlayerScript>();
        playerTalk = GetComponent<MakePlayerTalk>();
    }

    void AdvanceGameState(int advanceStep)
    {
        gameState += advanceStep;
    }

    public void CheckGameStateAndDoStuff(int advanceNumber)
    {
        switch (gameState)
        {
            case 0: //Dude er lige stået ud af bilen og skal have noget benzin
                //Play voice line: "I need to pay for gas inside before it can pump"
                playerTalk.StartNewLine("I need to pay for gas inside before it can pump.");
                break;

            case 1: //Når man snakker med Clerk første gang
                //Start dialogue med Clerk
                if (playerTalk.imTalking)
                {
                    playerTalk.StartNewLine("Hello, can I get 10 gallons of gas?");
                    DialogueFlags.instance.SetFlag("1st question");
                }
                break;

            case 2: //Interact with Gas pump, but no receipt
                //Play voice line: "Where's the receipt...?"
                break;   

            case 3: //Talk with clerk AGAIN
                    //Play voice line: "Uh, I paid for gas???"

                //If player walks into the mysterious room (not bathroom){
                //   The player can pick up an object (then play voice line: "huh, an [ITEM]" 
                //}   ---ITEM GET 1/2---
                break;

            case 4: //Pump gas into car, SUCCESFULY
                //Play voice line: "At least it pumps now"
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
