using Unity.VisualScripting;
using UnityEngine;

public class CameraWhenInBathroom : MonoBehaviour
{
    public GameObject Player;
    public Vector3 camOffset;
    public GameObject bathroomTrigger;
    public Camera bathroomCamera;
    public GameObject bathroomCameraOnPlayer;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bathroomTrigger)
        {
            //Enable this camera
            bathroomCameraOnPlayer.SetActive(true);
            bathroomCamera.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == bathroomTrigger)
        {
            //Disable this camera
            bathroomCameraOnPlayer.SetActive(false);
            bathroomCamera.enabled = true;

        }
    }

    void Update()
    {
        //Follow player with 
        bathroomCameraOnPlayer.transform.position = Player.transform.position + camOffset;

    }
}