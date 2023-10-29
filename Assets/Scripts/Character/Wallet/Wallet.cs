using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int balance;

    public Wallet(int initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(int amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            Debug.LogError("Amount to deposit must be positive.");
        }
    }

    public void Withdraw(int amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
        else if (amount > balance)
        {
            Debug.LogError("Insufficient funds.");
        }
        else
        {
            Debug.LogError("Amount to withdraw must be positive.");
        }
    }

    public int GetBalance()
    {
        return balance;
    }
}
