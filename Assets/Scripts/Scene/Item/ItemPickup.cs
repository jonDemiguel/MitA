using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehavior collide = collision.GetComponent<PlayerBehavior>();
        if (collide != null)
        {
            GetComponent<IPickupObject>().OnPickup(collide);
            Destroy(gameObject);
        }

    }
}