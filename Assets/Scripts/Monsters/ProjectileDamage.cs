using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damageAmount;
    private bool hasDamagedPlayer = false; 

    void Start()
    {
    }

    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") && !hasDamagedPlayer) {
            // Pass the collided object to AttackPlayer
            AttackPlayer(collision.gameObject); 
            // Set the flag to prevent further damage
            hasDamagedPlayer = true; 
        }
    }

    void AttackPlayer(GameObject player) {
        // Perform attack logic here
        Debug.Log("Projectile attacks player for " + damageAmount + " damage!");

        // Deal damage to the player (you should have a PlayerBehavior script with a PlayerTakeDmg method)
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        if (playerBehavior != null) {
            playerBehavior.PlayerTakeDmg(damageAmount);
        }
    }
}
