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
    bool userHasMadeSelection = false;
    void Start()
    {
        playerSta = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        levelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WaitForUserInput()
    {
        // Set up your menu UI and wait for the user to make a selection
        // For example, wait for a button press or some user interaction
        while (!userHasMadeSelection)
        {
            yield return null;
        }

        // Once the user has made a selection, the coroutine will continue
    }

    public void closeMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        userHasMadeSelection = false;
        levelMenu.SetActive(false);
        if(pausemenu != null)
        {
            pausemenu.ResumeGame();
        }
    }
    public void openMenu()
    {
        Time.timeScale = 0f;
        isPaused = true;
        if(levelMenu != null)
        {
            levelMenu.SetActive(true);
        }
        
        //levelPointText.text = "Level Points: " + lv.levelPoint.ToString();
    }
    public void updatePointText()
    {
        //levelPointText.text = "Level Points: " + lv.levelPoint.ToString();
    }
    public void increaseHealth()
    {
        userHasMadeSelection = true;
        
        playerSta.LevelUpHealth();
        
    }

    public void increaseDamage()
    {
        userHasMadeSelection = true;

        playerSta.LevelUpDamage();
    }

    public void increaseSpeed()
    {
        userHasMadeSelection = true;

        playerSta.LevelUpSpeed();
    }

    public void increaseCritical()
    {
        userHasMadeSelection = true;

        playerSta.LevelUpCritChance();
    }
}
