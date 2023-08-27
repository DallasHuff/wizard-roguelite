using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float playerSpeed = 2.0f;
    [SerializeField]
    public float jumpHeight = 1.0f;
    [SerializeField]
    public float gravityValue = -9.81f;
    [SerializeField]
    public float rotationSpeed = 8.0f;
    [SerializeField]
    public float slideDistance = 5.0f;
    [SerializeField]
    public Vector3 Drag;
    [SerializeField]
    public float slideSpeed;
    [SerializeField]
    public float slideTime;

    public Vector3 moveDir;

    public CharacterController controller;
    public PlayerInput playerInput;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public Transform cameraTransform;

    public InputAction moveAction;
    public InputAction jumpAction;
    public InputAction slideAction;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        slideAction = playerInput.actions["Slide"];


    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        /*
        if (slideAction.triggered && groundedPlayer)
        {
            playerVelocity += Vector3.Scale(transform.forward, slideDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
        }

        playerVelocity.x /= 1 + Drag.x * Time.deltaTime;
       
        playerVelocity.z /= 1 + Drag.z * Time.deltaTime;
        
        */
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        // Rotate towards camera direction
        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
    }

}
