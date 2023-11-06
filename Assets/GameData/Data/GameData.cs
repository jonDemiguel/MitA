using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int experience;
    public int playerMAXHP;
    public int armor;

    public GameData()
    {
        this.level = 1;
        this.experience = 0;
        this.playerMAXHP = 100;
        this.armor = 0;
    }
}