using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Control
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform playerCam;

        public float speed = 6f;
        private float gravity = -9.81f;
        [SerializeField] private float gravityMultiplier = 3.0f;
        private float velocity;

        public float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;

        // Update is called once per frame
        void FixedUpdate()
        {
            ApplyGravity();
            Move();

        }

        private void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                // turns the player to the direction of running
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                // moves player based on camera
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                // normalizes speed  so you can't speed up by running diagonally, or slow down if you lag
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }

        private void ApplyGravity()
        {
            if (controller.isGrounded && velocity < 0.0f)
            {
                velocity = -1f;
            }
            else
            {
                velocity += gravity * gravityMultiplier * Time.deltaTime;
            }
            Vector3 grav = new Vector3(0f, velocity, 0f);
            controller.Move(grav * Time.deltaTime);
        }
    }
}