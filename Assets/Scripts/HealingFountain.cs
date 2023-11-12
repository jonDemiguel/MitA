using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFoundation : MonoBehaviour
{
    public float healingRatePerSecond = 0.1f;  // Healing rate per second (10%)
    public int maxHealingPerSecond = 10000;  // Max healing per second (rounded to nearest integer)

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehavior playerBehavior = other.GetComponent<PlayerBehavior>();
            if (playerBehavior != null)
            {
                // Calculate the healing amount
                float healingAmount = Time.deltaTime * playerBehavior.MaxPlayerHP * healingRatePerSecond;

                // Round the healing amount to the nearest integer
                int roundedHealingAmount = Mathf.RoundToInt(healingAmount);

                // Ensure that the healing amount does not exceed the max healing per second
                int finalHealingAmount = Mathf.Min(roundedHealingAmount, maxHealingPerSecond);

                // Apply the healing to the player
                playerBehavior.Heal(finalHealingAmount);
            }
        }
    }
}
