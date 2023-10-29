using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private DamageFlash damageFlash;
    void Start()
    {
        damageFlash = GetComponent<DamageFlash>();
    }

    void Update()
    {
        
    }

    public void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        Debug.Log("Player health = " + GameManager.gameManager._playerHealth.Health);
        if (GameManager.gameManager._playerHealth.Health <= 0)
        {
            Die();
        }
        else
        {
            damageFlash.Flash(); // Flash the sprite red when taking damage
        }
    }

    private void Die()
    {
        // Handle player death logic here (e.g., play death animation, show game over screen, etc.)
        
        Destroy(gameObject);
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PlayerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.HealUnit(heal);
    }
}
