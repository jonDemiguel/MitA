using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharHP : MonoBehaviour
{
    public int MaxPlayerHP = 100;
    public int currentPlayerHP = 100;
    [SerializeField] PlayerHPstats hpBar;
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
        if(currentPlayerHP <= 0)
        { return; }

        currentPlayerHP += amount;
        if (currentPlayerHP > MaxPlayerHP)
        {
            currentPlayerHP = MaxPlayerHP;
        }
    }
}
