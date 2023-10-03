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
    public double modifier = 1.8171;
    //public GameObject[] enemySpawnSystem;
    public GameObject prefab;
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
        if (enemySpawned >= (startEnemyCount * Math.Pow(modifier, wave)))
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
            //int type = rnd.Next(0, enemySpawnSystem.Length);
            //if(type == 0)
            /*    Instantiate(Resources.Load<GameObject>("red_eye_monster")).name = "red_eye_monster";*/
            //  if (type == 1)
            //Instantiate(Resources.Load<GameObject>("Purple_Ghost_Monster")).name = "Purple_Ghost_Monster";
            //            Instantiate(enemySpawnSystem[type]);

            Instantiate(prefab, new Vector3(0, 0, 0f), transform.rotation);

            //enemy.name = "Enemy" + i;
            enemySpawned++;
            enemyCount++; // add an enemy when it's spawned
        }
    }
}
