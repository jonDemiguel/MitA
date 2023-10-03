using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public int damageAmount = 5;

    void Start()
    {

    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);
            if (distanceToPlayer <= 1)
            {
                AttackPlayer(player);
                Destroy(gameObject);
                Debug.Log("Destroyed" + gameObject);
            }
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
