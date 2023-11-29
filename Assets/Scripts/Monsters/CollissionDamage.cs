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
        // This method might not be needed anymore if all logic is handled in OnCollisionEnter2D
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            AttackPlayer();
            StartCoroutine(AttackCooldown());
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AttemptAttack());
        }
    }

    IEnumerator AttemptAttack()
    {
        if (canAttack)
        {
            AttackPlayer();
            yield return StartCoroutine(AttackCooldown());
        }
    }

    void AttackPlayer()
    {
        //Debug.Log("Monster attacks player for " + damageAmount + " damage!");
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
