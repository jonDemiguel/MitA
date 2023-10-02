using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float sanity = 100f;
    public float sanityThreshold = 30f;

    private void Update()
    {
        // Decrease sanity over time (e.g., due to player actions).
        sanity -= Time.deltaTime;

        // Check if sanity is below the threshold to switch scenes.
        if (sanity <= sanityThreshold)
        {
            SceneManager.LoadScene("DistortedScene");
        }
    }
}
