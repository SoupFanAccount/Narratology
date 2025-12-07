using UnityEngine;

public class GasArea_NotToilet : MonoBehaviour
{
    public SpeedCheck speedCheck;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            speedCheck.needsGas = true;
            speedCheck.carInside = true;
            speedCheck.PlayGasAnimation();
        }
    }
}
