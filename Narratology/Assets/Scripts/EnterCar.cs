using UnityEngine;

public class EnterCar : MonoBehaviour
{
    public SpeedCheck car;

    bool playerInside = false;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("stimkyy");
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
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            car.EnterCar();
        }
    }
}