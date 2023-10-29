using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int MaxPlayerHP = 100;
    public int currentPlayerHP = 100;
    public int armor = 0;


    [SerializeField] PlayerHPstats hpBar;

    private void Start()
    {
        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }

    public void DamageTaken(int damage)
    {
        applyArmor(ref damage);

        currentPlayerHP -= damage;

        if (currentPlayerHP <= 0)
        {
            Debug.Log("Game Over: You Are Dead!");
        }

        hpBar.StatePlayer(currentPlayerHP, MaxPlayerHP);
    }

    private void applyArmor(ref int damage)
    {
        damage -= armor;
        if (damage <= 0) { damage = 0; }

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