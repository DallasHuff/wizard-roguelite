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
    public float JumpTimeout = 0.50f;
    [SerializeField]
    public float FallTimeout = 0.15f;
    [SerializeField]
    public Vector3 Drag;
    [SerializeField]
    public float slideSpeed;
    [SerializeField]
    public float slideTime;

    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;
    private float _verticalVelocity;

    // Temp ground check
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;
    bool isGrounded;

    public Vector3 moveDir;

    public CharacterController controller;
    public PlayerInput playerInput;
    public Vector3 playerVelocity;
    private bool groundedPlayer;
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

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded)
        {
            // reset the fall timeout timer
            _fallTimeoutDelta = FallTimeout;
            if (playerVelocity.y < 0.0f)
            {
                playerVelocity.y = -1f;
            }
        }
        else
        {
            // reset the jump timeout timer
            _jumpTimeoutDelta = JumpTimeout;

            // fall timeout
            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }
        }

        /*
            if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }*/

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpAction.triggered && isGrounded && _jumpTimeoutDelta <= 0.0f)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if (_jumpTimeoutDelta >= 0.0f)
        {
            _jumpTimeoutDelta -= Time.deltaTime;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        // Rotate towards camera direction
        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
    }

}
