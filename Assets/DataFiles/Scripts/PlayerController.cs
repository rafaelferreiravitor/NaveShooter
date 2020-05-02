using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class PlayerController : MonoBehaviour
{

    Control inputActions;
    Vector2 movementInput;

    [Header ("ScreenPosition")]
    [SerializeField] float xRange = 3f;
    [SerializeField] float yRange = 1.5f;
    

    [Header ("General")]
    [Tooltip( "ms^-1")] [SerializeField] float controlSpeed = 10f;
    [SerializeField] private float positionPitchFactor = -5;
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float positionYawFactor = 6.5f;
    [SerializeField] private float controlRollFactor = -30f;
    [SerializeField] float pitchFactor = -5f;
    //[SerializeField] float yawFactor = 14f;
    //[SerializeField] float rollFactor = 30f;
    float xThrow, yThrow;

    bool isControllEnable = true;

    [Header ("Guns settings")]
    [SerializeField] private GameObject[] Guns;
    private List<ParticleSystem> ParticleGun = new List<ParticleSystem>();

    private void Start()
    {
        
        foreach (var item in Guns)
        {
            ParticleGun.Add(item.GetComponent<ParticleSystem>());
        }
         
    }

    private void Awake()
    {
        inputActions = new Control();
        inputActions.ActionMap.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputActions.ActionMap.Fire.performed += ctx => Shoot(ctx.ReadValueAsButton());

    }


    public void Update()
    {
        
        Move();
    }

    private void Move()
    {
        if (isControllEnable)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }

    private void Shoot(bool shoot)
    {
        foreach (var item in ParticleGun)
        {
            var main = item.main;
            main.loop = shoot;
            if (shoot)
                item.Play();
            else
                item.Stop();
        }
        
    }

    public void OnPlayerDeath() // called by CollisionHandler
    {
        isControllEnable = false;
    }

    private void ProcessRotation()
    {

        /*float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        */
        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

//        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

        float pitch = -90 - pitchFactor * yThrow;
        //float yaw = transform.localPosition.x * pitchFactor;
        //float roll =  rollFactor * xThrow;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
;    }

    private void ProcessTranslation()
    {
        //Debug.Log(movementInput);
        xThrow = movementInput.x;
        yThrow = movementInput.y;

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


}
