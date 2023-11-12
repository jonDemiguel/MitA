using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float maxPlayerHP = 100f; // Change to float
    public float currentPlayerHP = 100f; // Change to float
    public int armor = 0;
    private DamageFlash damageFlash;
    [SerializeField] PlayerHPstats hpBar;
    private float healthBoost = 0f; // Change to float
    private Coroutine healthRegenCoroutine;
    void Start()
    {
        damageFlash = GetComponent<DamageFlash>();
        hpBar.StatePlayer(currentPlayerHP, maxPlayerHP);
    }

    public void PlayerTakeDmg(float dmg) // Change to float
    {
        // Apply armor
        applyArmor(ref dmg);

        // Apply damage
        currentPlayerHP -= dmg;
        // Check if player is dead
        if (currentPlayerHP <= 0)
        {
            Die();
        }
        else
        {
            damageFlash.Flash(); // Flash the sprite red when taking damage
        }

        // Update health bar
        hpBar.StatePlayer(currentPlayerHP, maxPlayerHP);
    }

    private void Die()
    {
        // Handle player death logic here (e.g., play death animation, show game over screen, etc.)
        Destroy(gameObject);
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Armor logic
    private void applyArmor(ref float damage) // Change to float
    {
        damage -= armor;
        if (damage <= 0f) { damage = 0f; }
    }

    public void StartHealthRegen(float duration)
    {
        if (healthRegenCoroutine == null)
        {
            healthRegenCoroutine = StartCoroutine(HealthRegen(duration));
        }
    }

    private IEnumerator HealthRegen(float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration && currentPlayerHP > 0f)
        {
            float regenAmount = maxPlayerHP * 0.1f * Time.deltaTime; // 10% of max health per second
            currentPlayerHP += regenAmount;

            // Ensure current health doesn't exceed max health
            if (currentPlayerHP > maxPlayerHP)
            {
                currentPlayerHP = maxPlayerHP;
            }

            hpBar.StatePlayer(currentPlayerHP, maxPlayerHP);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Health regeneration has ended
        healthRegenCoroutine = null;
    }

    public void ApplyHealthBoost(float boostAmount) // Change to float
    {
        // Apply the health boost
        maxPlayerHP += boostAmount;
        currentPlayerHP += boostAmount;
        healthBoost += boostAmount;

        // Update the health bar
        hpBar.StatePlayer(currentPlayerHP, maxPlayerHP);
    }

    public void RevertHealthBoost(float boostAmount) // Change to float
    {
        // Revert the health boost
        maxPlayerHP -= boostAmount;
        if (currentPlayerHP > maxPlayerHP)
        {
            currentPlayerHP = maxPlayerHP;
        }
        healthBoost -= boostAmount;

        // Update the health bar
        hpBar.StatePlayer(currentPlayerHP, maxPlayerHP);
    }

    // Heal logic
    public void Heal(float amount) // Change to float
    {
        if (currentPlayerHP <= 0f)
        { // Player is dead, remove health boost
            RevertHealthBoost(healthBoost);
            return;
        }

        currentPlayerHP += amount;
        if (currentPlayerHP > maxPlayerHP)
        {
            currentPlayerHP = maxPlayerHP;
        }
        hpBar.StatePlayer(currentPlayerHP, maxPlayerHP);
    }
}
