using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float timeToLive = 2f;
    float ttl = 2f;

    void OnEnable()
    {
        ttl = timeToLive;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
