using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform orientation;

    [Header("Movement")]
    private float movementSpeed = 6f;
    float movementMultiplier = 10f;
    public float walkSpeed;
    public float sprintSpeed = 10;

    [SerializeField] float airMultiplier = 0.4f;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Drag")]
    float groundDrag = 6f;
    float airDrag = 2f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
        [SerializeField] LayerMask groundMask;

    bool isGrounded;
    float groundDisctance = 0.4f;
    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

        RaycastHit slopeHit;
    Rigidbody rb;

    public MoveState state;


    public enum MoveState
    {
        walking, 
        sprinting,
         air
    }

     private void StateHandler()
    {
        //mode - sprinting
        if(isGrounded && Input.GetKey(sprintKey))
        {
            state = MoveState.sprinting;
            movementSpeed = sprintSpeed;
        }
        else if (isGrounded)
        {
            state = MoveState.walking;
            movementSpeed = walkSpeed;
        }
        else
        {
            state = MoveState.air;
        }
    }
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if(slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDisctance, groundMask );

        MovementInput();
        ControllDrag();
        StateHandler();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void MovementInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement= Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ControllDrag()
    {
        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * movementMultiplier, ForceMode.Acceleration);

        }
        else if(isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * movementSpeed * movementMultiplier, ForceMode.Acceleration);

        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * airMultiplier, ForceMode.Acceleration);
        }
    }
}