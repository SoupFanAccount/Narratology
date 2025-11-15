using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Camera mainCamera;
    public GameObject actionIndicator;

    [Header("Dialogue")]
    public string[] dialogueLines;

    void Start()
    {
        actionIndicator.SetActive(false);
        mainCamera = Camera.main;
    }

    // This shows the indicator
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(true);
        }
    }

    // This hides the indicator
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(false);
        }
    }

    
    public void StartDialogueFromPlayer()
    {
        DialogueManager.instance.StartDialogue(dialogueLines, this);
    }

    // Hide the indicator when dialogue starts.
    private void OnDisable()
    {
        actionIndicator.SetActive(false);
    }

    void LateUpdate()
    {
        if (actionIndicator.activeInHierarchy)
        {
            actionIndicator.transform.rotation = mainCamera.transform.rotation;
        }
    }
}