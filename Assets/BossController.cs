using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject secondPhasePrefab; // Assign in the Inspector
    private EnemyHealth enemyHealth; // Reference to the EnemyHealth script
    private bool transitionedToSecondPhase = false;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>(); // Get the EnemyHealth component
        if (enemyHealth == null)
        {
            Debug.LogError("EnemyHealth component not found on the boss!");
        }
    }

    void Update()
    {
        // Check if the EnemyHealth script is attached and health is below a certain threshold
        if (enemyHealth != null && !transitionedToSecondPhase)
        {
            if (enemyHealth.currentHealth <= enemyHealth.maxHealth / 2)
            {
                TransitionToSecondPhase();
                transitionedToSecondPhase = true;
            }
        }
    }

    private void TransitionToSecondPhase()
    {
        if (secondPhasePrefab != null)
        {
            Instantiate(secondPhasePrefab, transform.position, transform.rotation);
            // Optionally, deactivate the current boss object
                gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Second phase prefab not set!");
        }
    }
}
