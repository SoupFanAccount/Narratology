using System;
using UnityEngine;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
   public WhereAreWe whereAreWe;

   private Rigidbody rb;
   private Animator anim;
    public float walkAnimThreshold;
   private float movementX;
   private float movementY;
   public float speed = 10;
   private InputAction interact;

    [SerializeField] CameraController camControlScript;

    [SerializeField] Transform cycle1Kiosk_Inside, cycle1Kiosk_Door, cycle1Toilet_Inside, cycle1Toilet_Door, cycleSecret_Door, cycleSecret_Inside;

    private bool atKioskDoor, atToiletDoor, atKioskInsideDoor, atToiletInsideDoor, atSecretDoor, atSecretInsideDoor;


    public bool item1Collected = false;
    public bool item2Collected = false;


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


        if (Input.GetKeyDown(KeyCode.E)){
            if(atKioskDoor)
            {
                transform.position = cycle1Kiosk_Inside.position;
                camControlScript.SwitchToKioskInsideCam();
            }
            if (atKioskInsideDoor)
            {
                transform.position = cycle1Kiosk_Door.position;
                camControlScript.SwitchToMainCam();
            }
            if (atToiletDoor)
            {
                transform.position = cycle1Toilet_Inside.position;
                camControlScript.SwitchToToiletCam();
            }
            if (atToiletInsideDoor)
            {
                transform.position = cycle1Toilet_Door.position;
                camControlScript.SwitchToAlleyCam();
            }
            if (atSecretDoor)
            {
                transform.position = cycleSecret_Inside.position;
                camControlScript.SwitchToSecretCam();
            }
            if (atSecretInsideDoor)
            {
                transform.position = cycleSecret_Door.position;
                camControlScript.SwitchToKioskInsideCam();
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

        if (other.CompareTag("CameraStateOutside"))
        {
            Debug.Log("Switched to main camera");
            camControlScript.SwitchToMainCam();
        }

        //Tjek hvis man er ved dører
        if (other.CompareTag("KioskDoor")) //Get into the kiosk from outside
        {
            atKioskDoor = true;
        }

        if (other.CompareTag("KioskInsideDoor")) //Go out from inside the kiosk
        {
            atKioskInsideDoor = true;
        }

        if (other.CompareTag("ToiletDoor")) //Go into toilet from outside
        {
            atToiletDoor = true;
        }

        if (other.CompareTag("ToiletInsideDoor")) //Go out from toilet to outside
        {
            atToiletInsideDoor = true;
        }




        if (other.CompareTag("SecretDoor"))
        {
            atSecretDoor = true;
        }
        
        if (other.CompareTag("SecretInsideDoor"))
        {
            atSecretInsideDoor = true;
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

        //Dør logik
        if (other.CompareTag("KioskDoor")) //Get into the kiosk from outside
        {
            atKioskDoor = false;
        }

        if (other.CompareTag("KioskInsideDoor")) //Go out from inside the kiosk
        {
            atKioskInsideDoor = false;
        }

        if (other.CompareTag("ToiletDoor")) //Go into toilet from outside
        {
            atToiletDoor= false;
        }

        if (other.CompareTag("ToiletInsideDoor")) //Go out from toilet to outside
        {
            atToiletInsideDoor = false;
        }


        if (other.CompareTag("SecretDoor"))
        {
            atSecretDoor = false;
        }

        if (other.CompareTag("SecretInsideDoor"))
        {
            atSecretInsideDoor = false;
        }
    }
}
