using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    public float groundDrag;

    public float jumpForce, jumpCooldown, airMultiplier;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Animation")]
    public Animator animator;
    public RuntimeAnimatorController idleAnimation, walkAnimation, sprintAnimation, jumpAnimation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    float localMoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        localMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // ground check - casts ray downward to limit of just underneath player height returns true if intersects with collider
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);
        if(grounded)
        {
            rb.drag = groundDrag;
        } 
        else
        {
            rb.drag = 0;
        }
        ProcessInput();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (!grounded) // jumping
        {
            animator.runtimeAnimatorController = jumpAnimation;
            Debug.Log("In the air");

        }
        else if (moveDirection.magnitude != 0)
        { // player is moving
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.runtimeAnimatorController = sprintAnimation;
            }
            else
            {
                animator.runtimeAnimatorController = walkAnimation;
            }
        }
        else
        { // player is idle
            animator.runtimeAnimatorController = idleAnimation;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            localMoveSpeed = moveSpeed * 2f;
        }
        else
        {
            localMoveSpeed = moveSpeed;
        }
    }

    private void ProcessInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // jumping
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;

        // movement for ground
        if (grounded) {
            rb.AddForce(moveDirection * localMoveSpeed * 10f, ForceMode.Force);
        }
        // movement for air
        else
        {
            rb.AddForce(moveDirection * localMoveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        // set y velocity to zero so that jump force doesn't compound
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
