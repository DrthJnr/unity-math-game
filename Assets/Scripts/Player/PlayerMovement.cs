using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform spawner;
    public GameObject Player;
    public float spawnerOffsetX = 2f;   // quanto ele deve ficar � direita
    public float speed = 10f;
    private float horizontal;
    private float jumpingPower = 19f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private HealthManagement healthManagement;
    private ButtonsFunctions buttonsFunctions;

    private void Start()
    {
        buttonsFunctions = GameObject.FindObjectOfType<ButtonsFunctions>();
    }
    // Update is called once per frame
    void Update()
    {
    #if UNITY_STANDALONE
        if (!BoolUseButton.useButtonControl)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        float moveInput = Input.GetAxisRaw("Horizontal");

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonsFunctions.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttonsFunctions.PauseGame();
        }
    #endif

        Vector3 spawnerLocalPos = spawner.localPosition; // Spawner
        spawnerLocalPos.x = isFacingRight ? Mathf.Abs(spawnerOffsetX) : -Mathf.Abs(spawnerOffsetX);
        spawner.localPosition = spawnerLocalPos;
        Flip();

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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

    public void GoLeft()
    {
        Debug.Log("Bot�o GoLeft pressionado " + horizontal);
        horizontal = -1f;
    }

    public void GoRight()
    {
        Debug.Log("Bot�o GoRight pressionado " + horizontal);
        horizontal = 1f;
    }
    public void StopMoving()
    {
        horizontal = 0f;
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }
    public void Jump2()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
    }
    
}