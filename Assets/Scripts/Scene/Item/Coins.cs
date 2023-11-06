using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinText;

    public void Add(int amount)
    {
        coinAcquired += amount;
        coinText.text = "Coins: " + coinAcquired.ToString();
    }
}
