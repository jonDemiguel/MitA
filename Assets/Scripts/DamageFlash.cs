using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public float flashDuration = 0.2f; // Duration of the flash effect in seconds
    public Color flashColor = Color.red; // Color of the flash (red in this case)

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flash()
    {
        // Change sprite renderer color to flash color
        spriteRenderer.color = flashColor;

        // Reset sprite renderer color after the specified duration
        Invoke("ResetColor", flashDuration);
    }

    void ResetColor()
    {
        // Reset sprite renderer color to its original color (white)
        spriteRenderer.color = Color.white;
    }
}
