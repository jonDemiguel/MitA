using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelMenu;
    public bool isPaused;
    public PlayerStats playerSta;
    public Level lv;
    public PauseMenu pausemenu;
    public TMP_Text levelPointText;
    void Start()
    {
        levelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        levelMenu.SetActive(false);
        pausemenu.ResumeGame();
    }
    public void openMenu()
    {
        Time.timeScale = 0f;
        isPaused = true;
        levelMenu.SetActive(true);
        
        levelPointText.text = "Level Points: " + lv.levelPoint.ToString();
    }
    public void updatePointText()
    {
        levelPointText.text = "Level Points: " + lv.levelPoint.ToString();
    }
    public void increaseHealth()
    {
        if (lv.levelPoint > 0)
        {
            playerSta.baseHealth += playerSta.healthIncreasePerLevel;
            lv.levelPoint--;
            updatePointText();
        }
    }

    public void increaseDamage()
    {
        if (lv.levelPoint > 0)
        {
            playerSta.baseDamage += playerSta.damageIncreasePerLevel;
            lv.levelPoint--;
            updatePointText();
        }
    }

    public void increaseSpeed()
    {
        if (lv.levelPoint > 0)
        {
            playerSta.baseSpeed += playerSta.speedIncreasePerLevel;
            lv.levelPoint--;
            updatePointText();
        }
    }

    public void increaseCritical()
    {
        if (lv.levelPoint > 0)
        {
            playerSta.baseCritChance += playerSta.critChanceIncreasePerLevel;
            lv.levelPoint--;
            updatePointText();
        }
    }
}
