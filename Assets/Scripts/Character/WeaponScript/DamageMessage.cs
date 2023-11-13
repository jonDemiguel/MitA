using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float timeToLive = 2f; // Time the message will be displayed
    float ttl = 2f; // Time to live

    void OnEnable()
    {
        // Set ttl
        ttl = timeToLive;
    }

    private void Update()
    {
        // Count down ttl
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
