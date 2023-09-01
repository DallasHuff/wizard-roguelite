using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Slide : MonoBehaviour
{
    StarterAssets.ThirdPersonController controllerScript;
    CharacterController charController;


    public PlayerInput playerInput;
    public InputAction slideAction;
    private StarterAssetsInputs _input;
    private bool groundedPlayer;
    public Vector3 playerVelocity;

    public float slideSpeed;
    public float slideTime;
    private float slideCD;
    public float slideCDTime;

    private float _targetRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        controllerScript = GetComponent<StarterAssets.ThirdPersonController>();
        charController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        _input = GetComponent<StarterAssetsInputs>();
        slideAction = playerInput.actions["Slide"];
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = charController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }



        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        if (slideCD > 0)
        {
            slideCD -= Time.deltaTime;
        }



        if (slideAction.triggered && groundedPlayer && slideCD <= 0) 
        {
            StartCoroutine(Slider());
        }
    }

    IEnumerator Slider()
    {
        float startTime = Time.time;

        while(Time.time < startTime + slideTime) 
        {
            //controllerScript.controller.Move(controllerScript.moveDir * slideSpeed * Time.deltaTime);
           //charController.Move(Slide.inputDirection * slideSpeed * Time.deltaTime);

            yield return null;
        }
        slideCD = slideCDTime;
    }
}
