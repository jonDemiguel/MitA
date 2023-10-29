using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int MaxPlayerHP = 100;
    public int currentPlayerHP = 100;
    [SerializeField] PlayerHPstats hpBar;
    
    [SerializeField] Wallet wallet;

    private void Start()
    {
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
        wallet = new Wallet(10);
    }

    // Method to be called when the character picks up a coin
    public void PickUpCoin(int amount)
    {
        wallet.Deposit(amount);
        Debug.Log("Picked up coin. Current balance: " + wallet.GetBalance());
    }

    // Method to be called when the player spends money in a shop
    public void SpendInShop(int amount)
    {
        wallet.Withdraw(amount);
        Debug.Log("Spent money in shop. Current balance: " + wallet.GetBalance());
    }

    public void DamageTaken(int damage)
    {
        currentPlayerHP -= damage;

        if (currentPlayerHP <= 0)
        {
            Debug.Log("Game Over: You Are Dead!");
        }

        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }


    public void Heal(int amount)
    {
        if (currentPlayerHP <= 0)
        { return; }

        currentPlayerHP += amount;
        if (currentPlayerHP > MaxPlayerHP)
        {
            currentPlayerHP = MaxPlayerHP;
        }
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }
}