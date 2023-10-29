using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollissionDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage dealt to the player per attack
    public float attackCooldown = 2f; // Cooldown time between attacks in seconds
    private bool canAttack = true;
    PlayerBehavior targetCharacter;
    public bool inHitBox = false;

    void Start()
    {
        // Start the Attack coroutine
        StartCoroutine(AttackCoroutine());
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            //if (distanceToPlayer <= attackDistance && canAttack)
            if (inHitBox && canAttack)
            {
                AttackPlayer();
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided");
            inHitBox = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("exited");
            inHitBox = false;
        }
    }

    void AttackPlayer()
    {
        // Perform attack logic here
        Debug.Log("Monster attacks player for " + damageAmount + " damage!");

        if (targetCharacter != null)
        {
            targetCharacter = targetCharacter.GetComponent<PlayerBehavior>();
        }

        targetCharacter.PlayerTakeDmg(damageAmount);
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
