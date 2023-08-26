using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Slide : MonoBehaviour
{
    PlayerController controllerScript;
    CharacterController charController;


    public PlayerInput playerInput;
    public InputAction slideAction;
    public bool groundedPlayer;
    public Vector3 playerVelocity;

    public float slideSpeed;
    public float slideTime;
    public float slideCD;


    // Start is called before the first frame update
    void Start()
    {
        controllerScript = GetComponent<PlayerController>();
        charController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
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
        /*
        if(slideCD > 0)
        {
            slideCD -= Time.deltaTime;
        }
        */

        if (slideAction.triggered && groundedPlayer) 
        {
            slideCD = 4f;
            StartCoroutine(Slider());
        }
    }

    IEnumerator Slider()
    {
        float startTime = Time.time;

        while(Time.time < startTime + slideTime) 
        {
            controllerScript.controller.Move(controllerScript.moveDir * slideSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
