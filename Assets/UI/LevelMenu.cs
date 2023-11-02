using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelMenu;
    public bool isPaused;
    void Start()
    {
        levelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                levelMenu.SetActive(false);
        }
    }

    public void closeMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        levelMenu.SetActive(false);
    }
    public void openMenu()
    {
        Time.timeScale = 0f;
        isPaused = true;
        levelMenu.SetActive(true);
    }
}
