using UnityEngine;

public class NeonScript : MonoBehaviour
{
    public Material neonMaterial1;
    public float blinkSpeedMin = 0.5f;
    public float blinkSpeedMax = 1.6f;

    private float timer;
    private bool isOn = true;

    void Start()
    {
        // Start with emission on
        ToggleEmission(true);
        // Initialize timer
        SetRandomTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Toggle the light state
            isOn = !isOn;
            ToggleEmission(isOn);
            SetRandomTimer();
        }
    }

    void ToggleEmission(bool enable)
    {
        if (enable)
        {
            neonMaterial1.EnableKeyword("_EMISSION");
            
        }
        else
        {
            neonMaterial1.DisableKeyword("_EMISSION");
        }
    }

    void SetRandomTimer()
    {
        timer = Random.Range(blinkSpeedMin, blinkSpeedMax);
    }
}
