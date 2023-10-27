using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//System.Serializable]
public class GameData
{
    public string playerName;
    public int wave;
    public int maxHealth;
}

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    void AquireData()
    {
        GameData data = new GameData();
        GameObject gameObject = GameObject.FindWithTag("EnemySpawner");
        EnemySpawnManager enemySpawner = gameObject.GetComponent<EnemySpawnManager>();
        data.wave = enemySpawner.GetWave();
        gameObject = GameObject.FindWithTag("Player");
    }

    // Load data from specified JSON file
    void LoadData()
    {

    }

    // Write data to json save file
    void WriteData()
    {

    }

}
