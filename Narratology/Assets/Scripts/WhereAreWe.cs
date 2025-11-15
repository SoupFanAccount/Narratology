using UnityEngine;

public class WhereAreWe : MonoBehaviour
{
    public int gameState = 0;

    void Start()
    {

    }

    public void AdvanceGameState(int advanceStep)
    {
        gameState += advanceStep;
    }

    public void CheckGameStateAndDoStuff()
    {
        switch (gameState)
        {
            case 0: //Dude er lige stået ud af bilen og skal have noget benzin
                //Play voice line: "I need to pay for gas inside before it can pump"

            case 1: //Når man snakker med Clerk første gang
                //Start dialogue med Clerk

            case 2: //Interact with Gas pump, but no receipt
                //Play voice line: "Where's the receipt...?"

            case 3: //Talk with clerk AGAIN
                //Play voice line: "Uh, I paid for gas???"

                    //If player walks into the mysterious room (not bathroom){
                    //   The player can pick up an object (then play voice line: "huh, an [ITEM]" 
                    //}   ---ITEM GET 1/2---

            case 4: //Pump gas into car, SUCCESFULY
                //Play voice line: "At least it pumps now"

            case 5: //Get into car and drive away
                //PLAY CAR CUTSCENE 1
                    //Play sounds:
                        //Internal monologue: "Must be because im tired"
                        //*Sees gas station again*, "Did I drive in circles?" *parks at station*
                        //Radio plays: "*inaudible* - seven people - *inaudible* - missing"

            case 6: //Arrive at gas station AGAIN
                //Play voice line: "I could use a bathroom. I'll go ask inside"

            case 7: //Talk with the clerk
                //Play dialogue: "Heyy", "Do you have pest poom?" "Yes, behind buliding"

            case 8: //

            default:
                Debug.Log("Noget gik galt! Ingen gameState??????");
                break;
        }

    }
}
