using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCam, alleyCam, kioskInsideCam;

    void Start()
    {
        mainCam.SetActive(true);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
    }

    public void SwitchToAlleyCam()
    {
        mainCam.SetActive(false);
        alleyCam.SetActive(true);
    }

    public void SwitchToMainCam()
    {
        mainCam.SetActive(true);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
    }

    public void SwitchToKioskInsideCam()
    {
        mainCam.SetActive(false);
        kioskInsideCam.SetActive(true);
    }
}
