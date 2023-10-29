using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        
    }

    public void PlayerTakeDmg(int dmg)
    {
        // GameManager.gameManager._playerHealth.DmgUnit(dmg);
        // Debug.Log("Player health = " + GameManager.gameManager._playerHealth.Health);
        // if (GameManager.gameManager._playerHealth.Health <= 0)
        // {
        //     Die();
        // }
        // else
        // {
        //     damageFlash.Flash(); // Flash the sprite red when taking damage
        // }
        
        applyArmor(ref dmg);
        currentPlayerHP -= dmg;
        if (currentPlayerHP <= 0)
        {
            Die();
        }
        else
        {
            damageFlash.Flash(); // Flash the sprite red when taking damage
        }
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }

    private void Die()
    {
        // Handle player death logic here (e.g., play death animation, show game over screen, etc.)
        Debug.Log("Game Over: You Are Dead!");
        Destroy(gameObject);
    }

    private void PlayerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.HealUnit(heal);
    }
    
    private void applyArmor(ref int damage)
    {
        damage -= armor;
        if (damage <= 0) { damage = 0; }

    }
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
