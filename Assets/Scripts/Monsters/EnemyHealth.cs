using UnityEngine;

public class EnemyHealth : MonoBehaviour, Destroyable
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    public GameObject[] itemsToDrop; // Array of items that can be dropped
    [SerializeField] int experience_gain = 400;
    [SerializeField] float chanceOfDrop = 1f;
    public bool isDestroyable;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            Die();
        }

        Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Enemy has been defeated.");
        
        // Drop a random item if any exist
        if (Random.value <= chanceOfDrop)
        {
            if (itemsToDrop.Length > 0)
            {
                int randomIndex = Random.Range(0, itemsToDrop.Length);
                Instantiate(itemsToDrop[randomIndex], transform.position, Quaternion.identity);
            }
        }

        // Find the player object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Try to get the Level component from the player
            Level playerLevel = player.GetComponent<Level>();
            if (playerLevel != null)
            {
                // Add experience to the player
                playerLevel.AddExperience(experience_gain);
            }
            else
            {
                Debug.LogError("Level component not found on player!");
            }
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        // Destroy the enemy object
        Destroy(gameObject, 1.0f);
    }
}
