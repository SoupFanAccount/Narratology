using UnityEngine;

public class GasArea_NotToilet : MonoBehaviour
{
    public SpeedCheck speedCheck;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            speedCheck.carInside = true;
            speedCheck.PlayGasAnimation();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            speedCheck.carInside = false;
        }
    }
}
