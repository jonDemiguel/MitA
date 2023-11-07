using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public string sceneName;
    public int enemiesKilled = 0;
    public UnitHealth _playerHealth = new UnitHealth(100, 100);

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }


    public void AddKillCount()
    {
        enemiesKilled++;
    }

    public void ResetKillCount()
    {
        enemiesKilled = 0;
    }

    public string GetActiveScene()
    {
        return sceneName;
    }

    public void NewScene()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
   public int GetKillCount()
   {
        return enemiesKilled;
   }

}
