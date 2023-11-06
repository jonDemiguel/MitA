using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject spellPrefab; // Assign your spell prefab in the inspector
    public float castDistance = 5f; // The distance from the player where the spell can be cast
    public float initialCastDelay = 5f; // Time in seconds to wait before first cast
    public float castDelay = 3f; // Time between casts after the first

    private GameObject player; // To store the player reference


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
        CastSpell();
        // Start the regular casting routine
        InvokeRepeating(nameof(CastSpell), castDelay, castDelay);
    }

    // Call this method to cast a spell
    public void CastSpell()
    {
        if (player != null)
        {
            // Get a random direction relative to the player's position
            Vector3 randomDirection = Random.insideUnitSphere * castDistance;
            randomDirection.y = 0; // Assuming you're working in 3D and want to cast on the ground plane

            // Calculate where to cast the spell
            Vector3 castPosition = player.transform.position + randomDirection;

            // Instantiate the spell at the castPosition
            GameObject spell = Instantiate(spellPrefab, castPosition, Quaternion.identity);

            // Optionally, if you want the spell to automatically destroy after the animation
            // Assuming your animation clip is 2 seconds long
            Destroy(spell, 1.5f);
        }
    }
}
