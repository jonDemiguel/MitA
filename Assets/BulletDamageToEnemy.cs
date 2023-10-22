using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageToEnemy : MonoBehaviour
{
    public bool inHitBox = false;
    public int damage = 25; // Bullet damage, change as necessary
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy"); 
        if (inHitBox)
        {
            AttackEnemy(enemy);
            Destroy(gameObject);
            Debug.Log("Destroyed" + gameObject);
        }  
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("collided");
            inHitBox = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("exited");
            inHitBox = false;
        }
    }
    void AttackEnemy(GameObject enemy)
    {
        // Perform attack logic here
        Debug.Log("Bullet attacks enemy for " + damage + " damage!");

        // Deal damage to the enemy (you should have an EnemyHealth script with a TakeDamage method)
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     Debug.Log("Bullet collided with: " + hitInfo.name); // hitInfo.name is the name of the object the bullet collided with.

    //     EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
    //     if (enemy != null)
    //     {
    //         enemy.TakeDamage(damage); // Call the TakeDamage function from the Enemy script
    //     }

    //     Destroy(gameObject); // Destroy bullet after hitting something
    // }
}
