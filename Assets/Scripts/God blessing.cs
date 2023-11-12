using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodBlessingTrigger : MonoBehaviour
{
    public int healthBoostAmount = 10000; // Adjust the amount as needed
    public float blessingDuration = 60f; // Duration of the health regeneration buff in seconds
    private bool isHealthBoosted = false;
    private bool isHealthRegenActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehavior playerBehavior = other.GetComponent<PlayerBehavior>();
            if (playerBehavior != null)
            {
                // Apply the health boost only once
                if (!isHealthBoosted)
                {
                    playerBehavior.ApplyHealthBoost(healthBoostAmount);
                    isHealthBoosted = true;
                }

                // Apply the health regeneration buff only once
                if (!isHealthRegenActive)
                {
                    playerBehavior.StartHealthRegen(blessingDuration);
                    isHealthRegenActive = true;
                }
            }
        }
    }
}
