using UnityEngine;

public class FogSpeed : MonoBehaviour
{
    public ParticleSystem fog;

    public string slowerTag = "FogSlower";
    public string fasterTag = "FogFaster";

    private float originalX;
    private float originalY;
    private float originalZ;
    private bool savedOriginals = false;

    private void Start()
    {
        var vel = fog.velocityOverLifetime;
        originalX = vel.xMultiplier;
        originalY = vel.yMultiplier;
        originalZ = vel.zMultiplier;
        savedOriginals = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var vel = fog.velocityOverLifetime;

        if(other.CompareTag(slowerTag))
        {
            vel.xMultiplier = 0f;
            vel.yMultiplier = 0f;
            vel.zMultiplier = 0f;
        }

        else if (other.CompareTag(fasterTag))
        {
            if (savedOriginals)
            {
                vel.xMultiplier = originalX;
                vel.yMultiplier = originalY;
                vel.zMultiplier = originalZ;
            }
            else { vel.enabled = true; }
        }
    }
}
