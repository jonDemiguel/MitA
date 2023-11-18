using UnityEngine;

public class PersistentPrefab : MonoBehaviour
{
    // Static variable to hold the instance of the prefab
    private static PersistentPrefab _instance;

    void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance == null)
        {
            // This is the first instance - make it the singleton instance
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // This is not the first instance - destroy it to ensure singleton
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Add any additional methods or properties needed for your prefab
}
