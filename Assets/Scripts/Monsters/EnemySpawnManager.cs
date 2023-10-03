using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager Instance;

    public List<GameObject> enemyTypes = new List<GameObject>();

    public float spawnArea = 1.5f;

    public float timeBetweenWaves = 15.0f; // give you 15 sec for default
    public float timeBetweenSpawns = 0.5f; // half sec between enemy spawns
    public int wave = 0; // start at wave 1
    public int startEnemyCount = 3; // number of enemies... our base amount
    public int addPerWave = 2; // how many new enemies per wave
    public double modifier = 1.8171;
    public GameObject[] enemySpawnSystem;
    private int enemyCount = 0; // active enemies
    private int enemySpawned = 0;
    

    //Called before game start
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    //Invokes new wave
    public void StartWave(int numWave)
    {
        InvokeRepeating("SpawnEnemies", timeBetweenSpawns, timeBetweenSpawns);
    }
     
    private bool CheckEnemyCount()
    {
        if (enemySpawned >= (startEnemyCount + wave * Math.Pow(modifier, wave)))
        {
            return true;
        }
        return false;

    }

    //End wave
    void EndWave()
    {
        wave++;
        enemyCount = 0;
        enemySpawned = 0;
        Invoke("StartWave", timeBetweenWaves);
    }

    public IEnumerator SpawnEnemies()
    {
        while (CheckEnemyCount())
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            System.Random rnd = new System.Random();
            int type = rnd.Next(0, enemySpawnSystem.Length);
            Instantiate(enemySpawnSystem[type]);

            //enemy.name = "Enemy" + i;
            enemySpawned++;
            enemyCount++; // add an enemy when it's spawned
        }
    }
}
