using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_eye_movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null) {
            Vector3 targetPosition = player.transform.position;
            MoveCharacter(targetPosition);

            // Determine the direction of movement based on the change in position
            float moveDirection = transform.position.x - previousPosition.x;

            // Flip the sprite based on the direction
            if (moveDirection < 0) {
                spriteRenderer.flipX = true; 
            } else if (moveDirection > 0) {
                spriteRenderer.flipX = false; 
            }
             previousPosition = transform.position;
        }
    }

    void MoveCharacter(Vector3 targetPosition)
    {
        // Calculate the movement step based on moveSpeed
        float step = moveSpeed * Time.deltaTime;

        // Move the monster towards the player object's position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Stop the monster's rotation (set it to a fixed angle):
            transform.rotation = Quaternion.Euler(0, 0, 0); // Adjust the angles as needed.
        }
    }

    void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        transform.rotation = Quaternion.Euler(0, 0, 0); // Reset rotation when the collision ends.
    }
}
}
