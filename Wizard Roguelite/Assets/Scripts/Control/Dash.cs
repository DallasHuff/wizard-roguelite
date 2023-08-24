using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private ThirdPersonController pm;

    [Header("Dash")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    private Animator _animator;
    private CharacterController _controller;
    private StarterAssetsInputs _input;
    private bool _hasAnimator;

    public KeyCode dashKey = KeyCode.E;



    // Start is called before the first frame update
    void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<ThirdPersonController>();

    }

    private void Dashing()
    {
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
        }

    private void ResetDash()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {
            Dashing();
        }
    }
}
