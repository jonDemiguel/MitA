using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject[] itemsToDrop; // Array of items that can be dropped

    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }

        Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Enemy has been defeated.");

        if (itemsToDrop.Length > 0)
        {
            int randomIndex = Random.Range(0, itemsToDrop.Length);
            Instantiate(itemsToDrop[randomIndex], transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
