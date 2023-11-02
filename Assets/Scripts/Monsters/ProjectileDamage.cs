using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{


    public int damageAmount;
    public bool inHitBox = false;

    void Start()
    {

    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (inHitBox)
            {
                AttackPlayer(player);
                Destroy(gameObject);
                Debug.Log("Destroyed" + gameObject);
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
    void AttackPlayer(GameObject player)
    {
        // Perform attack logic here
        Debug.Log("Projectile attacks player for " + damageAmount + " damage!");

        // Deal damage to the player (you should have a PlayerBehavior script with a PlayerTakeDmg method)
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        if (playerBehavior != null)
        {
            playerBehavior.PlayerTakeDmg(damageAmount);
        }
    }
}
