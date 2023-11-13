using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 2f; // Adjust this range to your needs.
    public int damage = 10;
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // private bool isAttacking = false;
    public float attackDuration = 0.5f;
    public bool isFlip = true;
    public float attackCooldown = 1f; // Cooldown time between attacks in seconds
    private bool canAttack = true;
    PlayerBehavior targetCharacter;
    GameObject player;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(AttackCooldown());
    }

    void Update()
    {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null) {
            Vector3 targetPosition = player.transform.position;

            // Calculate the distance between the monster and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= attackRange && canAttack) {
                // Player is in attack range
                animator.SetTrigger("isClose");
                Invoke("Attack", attackDuration);
                canAttack = false;
            } else {
                // Determine the direction of movement based on the target position
                float moveDirection = targetPosition.x - transform.position.x;

                // Flip the sprite based on the direction
                if (moveDirection > 0) {
                    if (isFlip) {
                        spriteRenderer.flipX = true;
                    } else {
                        spriteRenderer.flipX = false;
                    }
                } else if (moveDirection < 0) {
                    if (isFlip) {
                        spriteRenderer.flipX = false;
                    } else {
                        spriteRenderer.flipX = true;
                    }
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
        // isAttacking = true;

        // Boolean Parameter for transition to correct animation
        // animator.SetBool("isClose", true);

        // Deal damage to the player 
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // if (player != null) {
        //     PlayerBehavior playerHealth = player.GetComponent<PlayerBehavior>();
        //     if (playerHealth != null) {
        //         playerHealth.PlayerTakeDmg(damage);
        //         Debug.Log("Attacks player for " + damage + " damage!");
        //     }
        // }

        if (targetCharacter == null)
        {
            targetCharacter = player.GetComponent<PlayerBehavior>();
    
        }
        targetCharacter.PlayerTakeDmg(damage);
        // Start a coroutine to reset isAttacking after the attack animation duration.
        // StartCoroutine(ResetIsAttacking());
}

IEnumerator ResetIsAttacking()
{

    // Wait for the duration of the animation
    yield return new WaitForSeconds(attackDuration);

    // Reset isAttacking after the attack animation is complete.
    // isAttacking = false;

    // Boolean for attack transition back to false
    // animator.SetBool("isClose", false);
}

IEnumerator AttackCooldown()
{
    while (true)
    {
        yield return new WaitForSeconds(attackCooldown);
        // Reset the attack cooldown after the specified cooldown duration
        canAttack = true;
    }
    // Wait for the duration of the animation
    // yield return new WaitForSeconds(attackCooldown);

    // // Reset isAttacking after the attack animation is complete.
    // canAttack = true;
}
}