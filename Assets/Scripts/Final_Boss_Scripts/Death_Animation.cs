using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private int maxHealth;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            // Get the maxHealth from the EnemyHealth script (if available)
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                maxHealth = enemyHealth.maxHealth;
                Debug.Log("Max Health: " + maxHealth);
            }

            if (maxHealth <= 0)
            {
                // Play the death animation
                animator.SetBool("isDead", true);

                // Delay the destruction of the enemy object to allow the death animation to play
                Destroy(gameObject, 4.0f);
            }
    }
}
