using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SpeedCheck : MonoBehaviour
{
    private float switchTimer = 8f;
    public bool isStopped = false;

    public Transform[] inPoints;
    public Transform[] outPoints;

    /*public Transform inStart;
    public Transform in2;
    public Transform in3;
    public Transform in4;
    public Transform in5;
    public Transform in6;

    public Transform out1;
    public Transform out2;
    public Transform out3;
    public Transform out4;
    public Transform outExit;*/

    public Animator carAnimator;

    public GameObject car;
    public GameObject guy;
    public GameObject openDoor;
    //public List<GameObject> inPoints;
    //public List<GameObject> outPoints;

    public CameraController camSwitch;

    public float speed = 15f;
    public float rotationSpeed = 3f;
    public float breakingDistance = 10f;
    public float reachThreshold = 0.1f;

    private int currentIndex = 0;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = speed;
        //camSwitch.SwitchToCrunchCam();

        carAnimator = GetComponent<Animator>();
        carAnimator.SetBool("isStopped", false);

        //List<Transform> inPoints = new List<Transform>() {inStart, in2, in3, in4, in5, in6};
        //List<Transform> outPoints = new List<Transform>() {out1, out2, out3, out4, outExit};
    }

    void Update()
    {
        StopCar();
        StartCar();
    }

    void StopCar()
    {
        bool finalSegment = currentIndex == inPoints.Length - 1;
        Transform target = inPoints[currentIndex];

        Vector3 direction = (target.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion lookRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRot,
                rotationSpeed * Time.deltaTime);
        }

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (finalSegment && distanceToTarget < breakingDistance)
        {
            currentSpeed = Mathf.Lerp(0f, speed, distanceToTarget / breakingDistance);
        }
        else
        {
            currentSpeed = speed;
        }

        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        if (distanceToTarget < 1f)
        {
            currentIndex++;

            if (currentIndex >= inPoints.Length)
            {
                currentIndex = inPoints.Length - 1;

                currentSpeed = 0f;
                enabled = false;
            }
        }

        if (currentIndex == inPoints.Length-1)
        {
            StartCoroutine(SwitchDelay(4f));
            isStopped = true;
            switchTimer = 0f;
        }
        IEnumerator SwitchDelay(float switchDelay)
        {
            yield return new WaitForSeconds(switchDelay);
            guy.SetActive(true);
            camSwitch.SwitchToMainCam();
        }
    }

    void StartCar()
    {

    }

    void Loop()
    {
        
    }
}
