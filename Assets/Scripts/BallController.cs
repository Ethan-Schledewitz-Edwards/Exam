using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BallController : MonoBehaviour
{
    [Header("Parameters")]
    private float defaultMoveSpeed = 7.5f;
    [SerializeField] private LayerMask _groundLayers;


    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private OffsetCam _offsetCam;

    [SerializeField] private Transform _feet;

    [Header("System")]
    private bool grounded;
    private bool MovingX = true;
    private float currentMoveSpeed = 7.5f;
    private bool moving;


    private void Awake()
    {
        InputManager.Init();

        currentMoveSpeed = defaultMoveSpeed;
    }


    private void Start()
    {
        // Subscribe Movement
        InputManager.controls.Game.LMB.performed += ctx =>
        {
            LeftMouseButton();
        };
    }

    private void FixedUpdate()
    {
        grounded = !GroundCheck();

        if(_rb.velocity.y < -2)
        {
            Die();
        }

        if (moving && grounded)
        {
            if (MovingX)
            {
                _rb.velocity = new Vector3(currentMoveSpeed, _rb.velocity.y, 0);
            }
            else
            {
                _rb.velocity = new Vector3(0,_rb.velocity.y, currentMoveSpeed);
            }
        }
    }


    private void LeftMouseButton()
    {
        // Start movment if not started
        if (!moving)
        {
            moving = true;
            _rb.useGravity = true;
            _offsetCam.AssignTarget(transform);
            return;
        }

        // Swap Axis
        MovingX = !MovingX;
    }

    // Returns if the player is on the ground
    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(_feet.position, 0.2f, -transform.up, out hit, _groundLayers);
    }

    private void Die()
    {
        enabled = false;
        _offsetCam.enabled = false;
        GameManager.Instance.PlayerDied();
    }
}
