using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackCooldown = 1f;
    private bool canAttack = true;
    PlayerBehavior targetCharacter;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Check if the player is in the hitbox and if the enemy can attack
        if (player != null && canAttack)
        {
            // Use a Raycast or another method to confirm that the player is within attack range
            // and there are no obstacles between the enemy and the player.
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            AttackPlayer();
            StartCoroutine(AttackCooldown());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // This method might not be needed anymore if all logic is handled in OnCollisionEnter2D
    }

    void AttackPlayer()
    {
        Debug.Log("Monster attacks player for " + damageAmount + " damage!");
        if (targetCharacter == null)
        {
            targetCharacter = player.GetComponent<PlayerBehavior>();
        }
        targetCharacter.PlayerTakeDmg(damageAmount);
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
