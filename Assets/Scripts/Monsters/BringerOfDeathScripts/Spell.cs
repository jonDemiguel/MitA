using UnityEngine;

public class Spell : MonoBehaviour
{
    public int damage = 5; // The damage the spell does

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the hitbox collided with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            PlayerBehavior playerBehavior = other.GetComponent<PlayerBehavior>();
            if (playerBehavior != null)
            {
                playerBehavior.PlayerTakeDmg(damage);
                Debug.Log("Spell attacks player for " + damage + " damage!");
            }

            // Destroy the spell after applying damage
            DestroySpell();
        }
    }

    // Call this method to destroy the spell after the animation
    public void DestroySpell()
    {
        // This method can be called by an animation event at the end of the spell animation
        Destroy(gameObject,1.3f);
    }
}
