using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageToEnemy : MonoBehaviour
{
    public bool inHitBox = false;
    // public int damage = 25; // Bullet damage, change as necessary
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy"); 
        if (inHitBox)
        {
            AttackEnemy(enemy);
            Destroy(gameObject);
        }  
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            inHitBox = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            inHitBox = false;
        }
    }
    void AttackEnemy(GameObject enemy)
    {
        PlayerStats stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        // Calculate critical hit
        
        bool isCritical = Random.value < stats.currentCritChance;
        int finalDamage = isCritical ? stats.currentDamage * 2 : stats.currentDamage;

        Debug.Log("Bullet attacks enemy for " + finalDamage + " damage!" + (isCritical ? " Critical Hit!" : ""));

        // Deal damage to the enemy (you should have an EnemyHealth script with a TakeDamage method)
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(finalDamage);
        }
    }
}
