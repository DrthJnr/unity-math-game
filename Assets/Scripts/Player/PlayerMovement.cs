using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Transform spawner;
    public GameObject Player;
    public float spawnerOffsetX = 2f;   // quanto ele deve ficar � direita
    public float moveSpeed = 10f;
    private Vector2 moveInput;
    private PlayerInput playerInput;
    public float jumpForce = 15f; // Fazer privado depois
    public float fallMultiplier = 2.5f; // Fazer privado depois
    public float lowJumpMultiplier = 3f; // Fazer privado depois
    private bool isjumping = false;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private HealthManagement healthManagement;

    private ButtonsFunctions buttonsFunctions;
    private void Start()
    {
        buttonsFunctions = GameObject.FindFirstObjectByType<ButtonsFunctions>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Flip();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !isjumping)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
    
    private void Flip()
    {
        if (isFacingRight && moveInput.x < 0f || !isFacingRight && moveInput.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Jump();
            isjumping = true;
        }
        if (context.canceled)
        {
            isjumping = false;
        }

    }
    private void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}