using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;

    // Base stats
    public float baseSpeed = 5.0f;
    public int baseDamage = 25;
    public int baseHealth = 100;
    public float baseCritChance = 0.1f; // 10% base crit chance

    // Stat growth per level
    public float speedIncreasePerLevel = 5f;
    public int damageIncreasePerLevel = 5;
    public int healthIncreasePerLevel = 20;
    public float critChanceIncreasePerLevel = 0.02f; // 2% increase per level

    // Current stats
    public float currentSpeed;
    public int currentDamage;
    public int currentHealth;
    public float currentCritChance;

    void Start()
    {
        UpdateStats();
    }

    public void LevelUp()
    {
        playerLevel++;
        UpdateStats();
    }

    void UpdateStats()
    {
        currentSpeed = baseSpeed + (speedIncreasePerLevel * (playerLevel - 1));
        currentDamage = baseDamage + (damageIncreasePerLevel * (playerLevel - 1));
        currentHealth = baseHealth + (healthIncreasePerLevel * (playerLevel - 1));
        currentCritChance = baseCritChance + (critChanceIncreasePerLevel * (playerLevel - 1));

        // Update health in the GameManager or relevant script handling health
        GameManager.gameManager._playerHealth.SetMaxHealth(currentHealth);
    }

    public void LevelUpHealth()
    {
        currentHealth += healthIncreasePerLevel;
        GameManager.gameManager._playerHealth.SetMaxHealth(currentHealth);
        PlayerBehavior playerBehavior = GetComponent<PlayerBehavior>();
        playerBehavior.SetHealth(currentHealth);
    }

    public void LevelUpDamage()
    {
        currentDamage += damageIncreasePerLevel;
    }

    public void LevelUpSpeed()
    {
        currentSpeed += speedIncreasePerLevel;
        
    }

    public void LevelUpCritChance()
    {
        currentCritChance += critChanceIncreasePerLevel;
    }


}
