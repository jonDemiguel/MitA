using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageToEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyable"))
        {
            DestroyableObject destroyableObject = collision.GetComponent<DestroyableObject>();
            if (destroyableObject != null)
            {
                destroyableObject.TakeDamage(5);
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AttackEnemy(collision.gameObject);
            Destroy(gameObject); // Destroy the bullet
        }
    }

    void AttackEnemy(GameObject enemy)
    {
        PlayerStats stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        // Calculate critical hit
        bool isCritical = Random.value < stats.currentCritChance;
        int finalDamage = isCritical ? stats.currentDamage * 2 : stats.currentDamage;

        Debug.Log("Bullet attacks enemy for " + finalDamage + " damage!" + (isCritical ? " Critical Hit!" : ""));

        // Deal damage to the specific enemy
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(finalDamage);
        }
    }
}
