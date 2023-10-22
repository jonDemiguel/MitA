using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;

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

    //Destroy game object if killed
    void Die() {
        Debug.Log("Enemy has been defeated.");
        Destroy(gameObject); 
    }

}
