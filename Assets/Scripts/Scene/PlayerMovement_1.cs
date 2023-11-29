using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [HideInInspector]
    public float moveSpeed; // Now hidden in Inspector and will be set by PlayerStats
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    // References
    private Rigidbody2D rb;
    private PlayerStats playerStats;
    private Animator animator; // Added for animation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>(); // Get the PlayerStats component
        animator = GetComponent<Animator>(); // Get the Animator component

        if (playerStats != null)
            moveSpeed = playerStats.currentSpeed; // Set moveSpeed to the currentSpeed from PlayerStats
        else
            Debug.LogError("PlayerStats component not found!");
    }

    void Update()
    {
        InputManagement();
        if (playerStats != null)
            moveSpeed = playerStats.currentSpeed; // Continuously update moveSpeed to reflect changes in PlayerStats

        // Set animator parameters
        if (animator != null)
        {
            animator.SetFloat("moveX", moveDir.x);
            animator.SetFloat("moveY", moveDir.y);
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
        Debug.Log(moveSpeed);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
            lastHorizontalVector = moveDir.x;

        if (moveDir.y != 0)
            lastVerticalVector = moveDir.y;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
