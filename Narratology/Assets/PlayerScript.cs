using System;
using UnityEngine;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    
   private Rigidbody rb;
   private Animator anim;
    public float walkAnimThreshold;
   private float movementX;
   private float movementY;
   public float speed = 10;
   private InputAction interact;

    [SerializeField] CameraController camControlScript;

    [SerializeField] Transform cycle1Kiosk_Inside, cycle1Kiosk_Door;

    
   // De her 2 holder styr på hvilken ting man kan interegere med currently 
   private GameObject currentCollectable;
   private GameObject currentInteractable;
   void Start()
   {
       rb = GetComponent<Rigidbody>();
       anim = GetComponent<Animator>();
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
           if (currentCollectable != null)
           {
               //inventory.Add(currentCollectable.name);
               Debug.Log("Du samlede " + currentCollectable.name + " op makker");
               Destroy(currentCollectable);
               currentCollectable = null;
           }
           else if (currentInteractable != null)
           {
               Debug.Log("Du interegerede med " + currentInteractable.name + " makker");
               // En metode her der gør noget tror jeg
           }
       }
   }

   private void FixedUpdate()
   {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       rb.AddForce(movement * speed);

        if(Math.Abs(movement.magnitude) >= walkAnimThreshold)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }


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

        if (other.CompareTag("BackAlley"))
        {
            Debug.Log("Switched to back alley camera");
            camControlScript.SwitchToAlleyCam();
        }
   }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BackAlley"))
        {
            Debug.Log("Switched to main camera");
            camControlScript.SwitchToMainCam();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("KioskDoor")) //Get into the kiosk from outside
        {
            //REPLACE MAYBE???
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = cycle1Kiosk_Inside.position;
                camControlScript.SwitchToKioskInsideCam();
            }
        }

        if (other.CompareTag("KioskInsideDoor")) //Go out from inside the kiosk
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = cycle1Kiosk_Door.position;
                camControlScript.SwitchToMainCam();
            }
        }
    }
}
