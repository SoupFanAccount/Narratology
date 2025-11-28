using UnityEngine;

public class StopGasBlink : MonoBehaviour
{
    public SpeedCheck speedCheck;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            speedCheck.carInside = false;
            speedCheck.PlayGasAnimation();
        }
    }
}
