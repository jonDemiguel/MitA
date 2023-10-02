    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_eye_movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackDistance = 1.5f; // Distance at which the monster attacks the player
    public int damageAmount = 10; // Amount of damage dealt to the player per attack
    public float attackCooldown = 2f; // Cooldown time between attacks in seconds

    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;
    private bool canAttack = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;

        // Start the Attack coroutine
        StartCoroutine(AttackCoroutine());
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null) {
            Vector3 targetPosition = player.transform.position;
            MoveCharacter(targetPosition);

            //
            float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

            if (distanceToPlayer <= attackDistance && canAttack)
            {
                AttackPlayer(player);
            }
            //


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

    void AttackPlayer(GameObject player)
    {
        // Perform attack logic here
        Debug.Log("Monster attacks player for " + damageAmount + " damage!");

        // Deal damage to the player (you should have a PlayerBehavior script with a PlayerTakeDmg method)
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        if (playerBehavior != null)
        {
            playerBehavior.PlayerTakeDmg(damageAmount);
        }

        // Put the attack on cooldown
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackCooldown);

            // Reset the attack cooldown after the specified cooldown duration
            canAttack = true;
        }
    }

    IEnumerator AttackCooldown()
    {
        // Put the attack on cooldown
        canAttack = false;

        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(attackCooldown);

        // Reset the attack cooldown
        canAttack = true;
    }
}
