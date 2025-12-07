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
    public SplineContainer inSpline;
    public SplineContainer outSpline;
    
    public SplineAnimate splineAnim;
    public Animator carAnimator;

    public GameObject car;
    public GameObject guy;
    public GameObject entity;

    public int round = 0;
    public GasArea_NotToilet gasArea;
    public bool carInside;

    public ParticleSystem stationFogSmall;
    public ParticleSystem stationFogBig;
    public ParticleSystem carFog;
    private ParticleSystem.EmissionModule smallEmission;
    private ParticleSystem.EmissionModule bigEmission;

    public CameraController camSwitch;
    public bool isStopped = false;

    [SerializeField] WhereAreWe whereAreWe;
    [SerializeField] UI_Dialogue_Test dialougeManager;

    public bool needsGas = false;

    private void Start()
    {
        smallEmission = stationFogSmall.emission;
        bigEmission = stationFogBig.emission;

        stationFogSmall.Stop();
        stationFogBig.Stop();
        carFog.Play();

        splineAnim.Container = inSpline;
        splineAnim.Loop = SplineAnimate.LoopMode.Once;
        splineAnim.Easing = SplineAnimate.EasingMode.EaseOut;

        splineAnim.Completed += OnSplineReachedEnd;
        
        //splineAnim.Completed += StopCar;
        splineAnim.Play();

        carAnimator = car.GetComponent<Animator>();
        carAnimator.SetBool("isStopped", false);

        //var smallEmission = stationFogSmall.emission;
        //var bigEmission = stationFogSmall.emission;
    }

    void Update()
    {
        //StartCar();
    }

    void OnSplineReachedEnd()
    {
        if(splineAnim.Container == inSpline)
        {
            if (!isStopped)
            {
                StartCoroutine(PlayStopAnimation());
            }
        }
        else
        {
            StartCoroutine(ResetLoop());
        }
    }

    public void PlayGasAnimation()
    {
        //entity.SetActive(false);
        if(carInside == true && round != 2 && needsGas)
        {
            carAnimator.SetBool("needsGas", true);
        }
        else
        {
            carAnimator.SetBool("needsGas", false);
        }
    }

    IEnumerator PlayStopAnimation()
    {
        smallEmission.rateOverTime = 30f;
        bigEmission.rateOverTime = 50f;

        stationFogSmall.Play();
        stationFogBig.Play();
        carFog.Stop();
        
        isStopped = true;
        carAnimator.SetBool("isStopped", true);

        yield return new WaitForSeconds(5f);

        entity.SetActive(false);
        if (dialougeManager.onGoingDialogue)
        {
            dialougeManager.EndDialogue();
        }
        guy.SetActive(true);
        whereAreWe.CheckGameStateAndDoStuff(1); //Advance to the next game state
        camSwitch.SwitchToMainCam();
    }

    public void EnterCar()
    {
        StartCoroutine(StartCar());
    }

    IEnumerator StartCar()
    {
        carAnimator.SetBool("isStopped", false);

        yield return new WaitForSeconds(2f);

        camSwitch.SwitchToCrunchCam();
        guy.SetActive(false);
        if (round == 1)
        {
            entity.SetActive(true);
        }

        splineAnim.Easing = SplineAnimate.EasingMode.EaseIn;
        splineAnim.Container = outSpline;

        yield return new WaitForSeconds(3f);

        splineAnim.Restart(true);
        isStopped = false;

        carFog.Play();


        yield return new WaitForSeconds(2f);

        smallEmission.rateOverTime = 0f;
        bigEmission.rateOverTime = 0f;

        stationFogSmall.Stop();
        stationFogBig.Stop();

    }

    IEnumerator ResetLoop()
    {
        round++;
        float3 startPos = inSpline.EvaluatePosition(0f);
        car.transform.position = startPos;

        float3 tangent = inSpline.EvaluateTangent(0f);
        car.transform.rotation = Quaternion.LookRotation(tangent);

        yield return null;

        splineAnim.Container = inSpline;
        splineAnim.Easing = SplineAnimate.EasingMode.EaseOut;
        splineAnim.Restart(true);
    }
}