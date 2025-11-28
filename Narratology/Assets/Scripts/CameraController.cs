using UnityEngine;

public class CameraController : MonoBehaviour 
{
    public GameObject mainCam, alleyCam, kioskInsideCam, toiletCam, carCam, secretDoor;

    void Start()
    {
        /*mainCam.SetActive(true);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
        toiletCam.SetActive(false);*/
    }

    public void SwitchToAlleyCam()
    {
        mainCam.SetActive(false);
        alleyCam.SetActive(true);
        toiletCam.SetActive(false);
    }

    public void SwitchToMainCam()
    {
        mainCam.SetActive(true);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
        toiletCam.SetActive(false);
        carCam.SetActive(false);
    }

    public void SwitchToKioskInsideCam()
    {
        mainCam.SetActive(false);
        kioskInsideCam.SetActive(true);
        secretDoor.SetActive(false);
    }

    public void SwitchToToiletCam()
    {
        toiletCam.SetActive(true);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
        //mainCam.SetActive(false); //Ensure that the main camera stays off
    }

    public void SwitchToCrunchCam()
    {
        toiletCam.SetActive(false);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
        carCam.SetActive(true);
    }
    public void SwitchToSecretCam() {
        kioskInsideCam.SetActive(false);
        secretDoor.SetActive(true);

    }
}
