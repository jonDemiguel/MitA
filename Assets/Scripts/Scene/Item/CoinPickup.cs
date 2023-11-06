using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour, IPickupObject
{
    [SerializeField] int coinAmount;

    public void OnPickup(PlayerBehavior character)
    {
        character.coins.Add(coinAmount);
    }
}
