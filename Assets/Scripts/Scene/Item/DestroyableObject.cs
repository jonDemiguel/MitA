using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour 
{

    public GameObject[] itemsToDrop; // Array of items that can be dropped

    public void TakeDamage (int damage)
    {
        Die();
    }


    void Die()
    {
        // Drop a random item if any exist
        if (itemsToDrop.Length > 0)
        {
            int randomIndex = Random.Range(0, itemsToDrop.Length);
            Instantiate(itemsToDrop[randomIndex], transform.position, Quaternion.identity);
        }


        // Destroy the enemy object
        Destroy(gameObject);
    }

}
