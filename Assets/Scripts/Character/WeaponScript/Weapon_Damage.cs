using UnityEngine;

public class Weapon_Damage : MonoBehaviour
{
    public int damageAmount = 10; 
    public string enemyTag = "Enemy"; 

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
