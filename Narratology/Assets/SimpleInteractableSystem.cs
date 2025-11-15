using System;
using UnityEngine;

public class SimpleInteractableSystem : MonoBehaviour
{
    Camera mainCamera;
    public GameObject actionIndicator;

    void Start()
    {
        actionIndicator.SetActive(false);
        mainCamera = Camera.main;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(false);
        }
    }

    void LateUpdate()
    {
        actionIndicator.transform.rotation = mainCamera.transform.rotation;
    }
}