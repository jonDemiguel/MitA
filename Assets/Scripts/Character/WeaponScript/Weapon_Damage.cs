using UnityEngine;

public class Weapon_Damage : MonoBehaviour
{
    public int damageAmount = 10; // Adjust the damage amount as needed.
    public string enemyTag = "Enemy"; // Set the tag for your enemy GameObjects.

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(enemyTag)) {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damageAmount);
                Debug.Log("Dealt " + damageAmount + " damage to an enemy.");
            }
        }
    }
}
