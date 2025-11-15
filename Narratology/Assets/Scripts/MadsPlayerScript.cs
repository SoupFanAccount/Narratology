using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class MadsPlayerScript : MonoBehaviour
{
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 10;
    private InputAction interact;

    
    // De her 2 holder styr på hvilken ting man kan interegere med currently 
    private GameObject currentCollectable;
    private GameObject currentInteractable;
   
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       interact = InputSystem.actions.FindAction("Interact");
       interact.Enable();
    }
   

    private void OnMove(InputValue movementValue)
    {
       Vector2 movementVector = movementValue.Get<Vector2>();
       movementX = movementVector.x;
       movementY = movementVector.y;
    }
   
    
    private void Update()
    {
        if (interact.WasPressedThisFrame())
        {
            // 1. CHECK DIALOGUE STATE FIRST
            // Check if the DialogueManager exists and if its dialogue UI is active
            if (DialogueManager.instance != null && DialogueManager.instance.IsDialogueActive())
            {
                // If it is, we are IN dialogue. Tell the manager to advance.
                DialogueManager.instance.AdvanceDialogue();
            }
            // 2. ELSE, DO YOUR NORMAL "ROAMING" ACTIONS
            else
            {
                // We are NOT in dialogue. Look for objects to interact with.
                if (currentCollectable != null)
                {
                    //inventory.Add(currentCollectable.name);
                    Debug.Log("Du samlede " + currentCollectable.name + "op makker");
                    Destroy(currentCollectable);
                    currentCollectable = null;
                }
                else if (currentInteractable != null)
                {
                    Debug.Log("Du interegerede med " + currentInteractable.name + " makker");
                    // Try to get the Interactable component from the object
                    Interactable interactableComponent = currentInteractable.GetComponent<Interactable>();
                    if (interactableComponent != null) {
                        interactableComponent.StartDialogueFromPlayer();
                    }
                }
            }
        }
    }
  
    // The IsDialogueActive() method has been REMOVED from here

    private void FixedUpdate()
    {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       rb.AddForce(movement * speed);

       if (movement != Vector3.zero)
       {
           transform.rotation = Quaternion.LookRotation(movement);
       }
    }


    // Her sættes den interactable og collectable variablerne
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Collectable"))
       {
           Debug.Log("Can collect: " + other.name);
           currentCollectable = other.gameObject;
       }

       if (other.CompareTag("Interactable"))
       {
           Debug.Log("Can interact with: " + other.name);
           currentInteractable = other.gameObject;
       }
    }
   
    // This is the bug fix. It clears the variables when you walk away.
    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Collectable"))
       {
           if (other.gameObject == currentCollectable)
           {
               currentCollectable = null;
           }
       }

       if (other.CompareTag("Interactable"))
       {
           if (other.gameObject == currentInteractable)
           {
               currentInteractable = null;
           }
       }
    }
}