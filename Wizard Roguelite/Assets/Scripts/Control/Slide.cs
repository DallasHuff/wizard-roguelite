using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slide : MonoBehaviour
{
    PlayerController controllerScript;

    public PlayerInput playerInput;
    public InputAction slideAction;
    public bool groundedPlayer;

    public float dashSpeed;
    public float dashTime;


    // Start is called before the first frame update
    void Start()
    {
        controllerScript = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();
        slideAction = playerInput.actions["Slide"];
    }

    // Update is called once per frame
    void Update()
    {
        if (slideAction.triggered && groundedPlayer)
        {
            StartCoroutine(Slider());
        }
    }

    IEnumerator Slider()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime) 
        {
            controllerScript.controller.Move(controllerScript.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
