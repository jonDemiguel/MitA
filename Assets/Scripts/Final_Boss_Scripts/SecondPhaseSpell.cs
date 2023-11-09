using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
    public GameObject spellPrefab; // Assign your spell prefab in the inspector
    public GameObject goblinPrefab; // Prefab for the goblin enemy
    public GameObject skeletonPrefab; // Prefab for the skeleton enemy
    public float castDistance = 5f; // The distance from the player where the spell can be cast
    private float initialCastDelay = 5f; // Time in seconds to wait before first cast
 
    public float castAnimationDuration = 2f; // Duration of the casting animation
    public float castDelay = 60f; // Time between casts after the first

    private GameObject player; // To store the player reference
    public bool isCasting = false; // Flag to indicate if casting is in progress

    void Start()
    {
        // Find the player GameObject by tag, make sure your player GameObject has the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Start the first spell cast after a delay
        StartCoroutine(InitialSpellCast());
    }

    IEnumerator InitialSpellCast()
    {
        yield return new WaitForSeconds(initialCastDelay);

        // Start the regular casting routine
        InvokeRepeating(nameof(CastSpell), 0, castDelay);
    }

    // Call this method to cast a spell
    public void CastSpell()
    {
        if (player != null && !isCasting)
        {
            isCasting = true;
            // Stop moving and play casting animation (replace "YourCastingAnimation" with the actual animation trigger name)
            GetComponent<Animator>().SetTrigger("isClose");

            // Wait for the casting animation duration
            StartCoroutine(CastSpellAfterAnimation());
        }
    }

    IEnumerator CastSpellAfterAnimation()
    {
        // Wait for the casting animation duration
        yield return new WaitForSeconds(initialCastDelay);

        // Get the player's position
        Vector3 playerPosition = transform.position;

        // Calculate positions for spawning enemies
        Vector3 northPosition = playerPosition + Vector3.forward * castDistance;
        Vector3 southPosition = playerPosition - Vector3.forward * castDistance;
        Vector3 westPosition = playerPosition - Vector3.right * castDistance;
        Vector3 eastPosition = playerPosition + Vector3.right * castDistance;

        // Spawn two goblins in northmost and southmost positions
        GameObject spellNorth = Instantiate(spellPrefab, northPosition, Quaternion.identity);
        Destroy(spellNorth, 1.5f);
        
        GameObject spellSouth = Instantiate(spellPrefab, southPosition, Quaternion.identity);
        Destroy(spellSouth, 1.5f);
        
        Instantiate(goblinPrefab, northPosition, Quaternion.identity);
        Instantiate(goblinPrefab, southPosition, Quaternion.identity);

        // Spawn two skeletons in westmost and eastmost positions
        // GameObject spellWest = Instantiate(spellPrefab, westPosition, Quaternion.identity);
        // Destroy(spellWest, 1.5f);
        // GameObject spellEast = Instantiate(spellPrefab, eastPosition, Quaternion.identity);
        // Destroy(spellEast, 1.5f);
        
        // Instantiate(skeletonPrefab, westPosition, Quaternion.identity);
        // Instantiate(skeletonPrefab, eastPosition, Quaternion.identity);

        // Resume movement
        isCasting = false;
    }
}
