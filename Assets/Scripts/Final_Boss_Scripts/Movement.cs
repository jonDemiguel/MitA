using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 0.6f; // Adjust this range to your needs.
    public int damage = 10;
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null) {
            Vector3 targetPosition = player.transform.position;

            // Calculate the distance between the monster and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= attackRange) {
                // Player is in attack range
                if (!isAttacking) {
                    // Trigger the attack animation and deal damage.
                    Attack();
                }
            } else {
                // Determine the direction of movement based on the target position
                float moveDirection = targetPosition.x - transform.position.x;

                // Flip the sprite based on the direction
                if (moveDirection > 0) {
                    spriteRenderer.flipX = true;
                } else if (moveDirection < 0) {
                    spriteRenderer.flipX = false;
                }

                // Move the monster if the player is out of attack range
                MoveCharacter(targetPosition);
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

void Attack()
{
        isAttacking = true;

        // Boolean Parameter for transition to correct animation
        animator.SetBool("isClose", true);

        // Deal damage to the player 
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            PlayerBehavior playerHealth = player.GetComponent<PlayerBehavior>();
            if (playerHealth != null) {
                playerHealth.PlayerTakeDmg(damage);
                Debug.Log("Attacks player for " + damage + " damage!");
                StartCoroutine(ResetIsAttacking());
            }
        }

        // Start a coroutine to reset isAttacking after the attack animation duration.
        
}

IEnumerator ResetIsAttacking()
{
    // Wait for the duration of the animation
    yield return new WaitForSeconds(0.5f);

    // Reset isAttacking after the attack animation is complete.
    isAttacking = false;

    // Boolean for attack transition back to false
    animator.SetBool("isClose", false);
    Debug.Log("I rest!");
}
}
