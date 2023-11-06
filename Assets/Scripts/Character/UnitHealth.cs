using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    // Fields
    int _currentHealth;
    int _currentMaxHealth;

    // Properties
    public int Health
    { get { return _currentHealth; } set { _currentHealth = value; } }

    public int MaxHealth
    { get { return _currentMaxHealth; } set { _currentMaxHealth = value; } }

    // Constructor
    public UnitHealth(int health, int maxHealth) 
    { 
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Methods
    public void DmgUnit(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }

    }

    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }
        if (_currentHealth > _currentMaxHealth) 
        {
            _currentHealth = _currentMaxHealth;
        }
    }


    public void SetMaxHealth(int maxHealth)
    {
        // Update the player's maximum health and fully heal them, or implement as desired
        _currentMaxHealth = maxHealth;
        _currentHealth = maxHealth; // Optional: Heal the player to full health on level up
        // // Update the player's maximum health and fully heal them, or implement as desired
        // this.maxHealth = maxHealth;
        // this.currentHealth = maxHealth; // Optional: Heal the player to full health on level up
    }
}
