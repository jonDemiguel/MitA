using UnityEngine;

public class Weapon_Damage : MonoBehaviour
{
    public int damageAmount = 10; 
    public string enemyTag = "Enemy";
    public string destroyableTag = "Destroyable";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(destroyableTag))
        {
            DestroyableObject destroyableObject = other.GetComponent<DestroyableObject>();
            if (destroyableObject != null)
            {
                destroyableObject.TakeDamage(damageAmount);
            }
        }
        if (other.CompareTag(enemyTag)) {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damageAmount);
                Debug.Log("Dealt " + damageAmount + " damage to an enemy.");
            }
        }
    }
}
