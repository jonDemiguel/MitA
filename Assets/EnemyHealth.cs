using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private UnitHealth unitHealth; // Uses the UnitHealth class you provided
    private DamageFlash damageFlash;
    void Start()
    {
        damageFlash = GetComponent<DamageFlash>();
        unitHealth = new UnitHealth(100, 100); // Initialize with max health 100
    }

    public void TakeDamage(int amount)
    {
        unitHealth.DmgUnit(amount);
        Debug.Log("Enemy health = " + unitHealth.Health);
        if (unitHealth.Health <= 0)
        {
            Die(); // If health is 0 or less, the enemy dies
        } else
        {
            // Play hurt animation/effects here
            damageFlash.Flash();
        }
    }

    void Die()
    {
        // Destroy the enemy or trigger death animation/effects here
        Destroy(gameObject);
    }
}
