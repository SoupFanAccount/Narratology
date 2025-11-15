using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCam, alleyCam, kioskInsideCam, toiletCam;

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
    }

    public void SwitchToKioskInsideCam()
    {
        mainCam.SetActive(false);
        kioskInsideCam.SetActive(true);
    }

    public void SwitchToToiletCam()
    {
        toiletCam.SetActive(true);
        alleyCam.SetActive(false);
        kioskInsideCam.SetActive(false);
        //mainCam.SetActive(false); //Ensure that the main camera stays off
    }
}
