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
            
            if (DialogueManager.instance != null && DialogueManager.instance.IsDialogueActive())
            {
                // Hvis man er i en dialog, bliver "interact" brugt til at gå videre i dialogen.
                DialogueManager.instance.AdvanceDialogue();
            }
            
            else
            {
                // Hvis man ikke er en dialog, så kan man interegere med objekter. 
                if (currentCollectable != null)
                {
                    //Vi kunne bruge inventory.Add(currentCollectable.name); e.g. hvis vi vil have et inventory system (men det har vi ik!)
                    Debug.Log("Du samlede " + currentCollectable.name + "op makker");
                    // DialogueFlags er et static script der holder styr på conditions.
                    // Så jeg kalder funktioner fra det når jeg skal have shit i det.
                    DialogueFlags.instance.SetFlag(currentCollectable.name);
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
  
    
    private void FixedUpdate()
    {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       rb.AddForce(movement * speed);

       if (movement != Vector3.zero)
       {
           transform.rotation = Quaternion.LookRotation(movement);
       }
    }


    
    // Trigger funktioner hernede
    
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