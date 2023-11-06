using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public int MaxPlayerHP = 100;
    public int currentPlayerHP = 100;
    public int armor = 0;
    private DamageFlash damageFlash;
    [SerializeField] PlayerHPstats hpBar;

    void Start()
    {
        damageFlash = GetComponent<DamageFlash>();
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }

    public void PlayerTakeDmg(int dmg)
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
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }

    private void Die()
    {
        // Handle player death logic here (e.g., play death animation, show game over screen, etc.)
        Destroy(gameObject);
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Armor logic
    private void applyArmor(ref int damage)
    {
        damage -= armor;
        if (damage <= 0) { damage = 0; }

    }

    // Heal logic
    public void Heal(int amount)
    {
        if (currentPlayerHP <= 0)
        { return; }

        currentPlayerHP += amount;
        if (currentPlayerHP > MaxPlayerHP)
        {
            currentPlayerHP = MaxPlayerHP;
        }
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }
}
