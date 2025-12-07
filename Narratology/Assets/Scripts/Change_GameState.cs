using UnityEngine;

public class Change_GameState : MonoBehaviour
{
    public WhereAreWe whereAreWe;
    public int HowManyStates = 1;
    public bool pressETrigger = false;

    /*private void OnEnable()
    {
        whereAreWe = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<WhereAreWe>();
    }*/ 
    //Det her virkede åbenbart ikke :) 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //When player runs into trigger, advance the game state :D
        {
            if(pressETrigger == true)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    whereAreWe.CheckGameStateAndDoStuff(HowManyStates);
                    Debug.Log("Changed GameState. Bye!");
                    Destroy(gameObject);
                }
            }
            else
            {
                whereAreWe.CheckGameStateAndDoStuff(HowManyStates);
                Debug.Log("Changed GameState. Bye!");
                Destroy(gameObject);
            }
        }
    }
}
