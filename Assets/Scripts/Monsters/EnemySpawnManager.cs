using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager Instance;

    
    //Time Offsets
    public float timeBetweenWaves = 100.0f;
    public float timeBetweenSpawns = 1.5f;

    //Num enemy attributes
    public int wave;
    public int startEnemyCount = 3;
    public double modifier = 1.8171;
    private int enemyCount = 0;
    private int enemySpawned = 0;
    bool stillEnemies;

    //In game assets
    public GameObject[] prefab;
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;
    public Camera mainCamera;
    public GameManager gameManager;
    String activeScene;
    String nextScene;

    //Called before game start
    private void Awake()
    {
        //Instance = this;
    }

    void Update()
    {
        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.NewScene();
        activeScene = gameManager.GetActiveScene();
        if (activeScene == "GameMap2")
        {
           nextScene = "Level2";
           wave = 0;
        }
        if (activeScene == "Level2")
        {
            nextScene = "Level3";
            wave = 1;
        }
        if (activeScene == "Level3")
        {
            nextScene = "FinalBossRoom";
            wave = 2;
        }
        StartCoroutine(SpawnEnemies());
        
    }

    //Invokes new wave
    public void StartWave()
    {
        //ADD INCREASED DIFICULTY OR OTHER ATTRIBUTES HERE
        InvokeRepeating("SpawnEnemies", timeBetweenSpawns, timeBetweenSpawns);
    }

    private bool CheckEnemyCount()
    {
        if (enemySpawned >= (startEnemyCount * Math.Pow(modifier, wave)))
        {
            return false;
        }
        return true;
    }

    //End wave
    void EndWave()
    {    
        gameManager.ResetKillCount();
        enemySpawned = 0;
        SceneManager.LoadScene(nextScene);
    }

    public Vector3 getSpawnLocation()
    {
        System.Random rnd = new System.Random();

        //Camera dimensions
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float halfWidth = cameraWidth / 2f;
        float halfHeight = cameraHeight / 2f;
        
        //Distance from edge of screen to monster
        float marginOffset = 5f;

        //Camera Location
        Vector3 cameraLoc = mainCamera.transform.position;
        Vector2 cameraPosition = new Vector2(cameraLoc.x, cameraLoc.y);
        
        //Random Angle to shoot from middle of scene
        int randAngle = rnd.Next(0, 360);
        Vector2 direction = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));

        //Intersection point from random angle to border of on camera scene
        Vector2 intersection = cameraPosition + new Vector2(direction.x * halfWidth, direction.y * halfHeight);
        Vector3 intersectionPoint = new Vector3(intersection.x, intersection.y, 0f);

        //Calculate to determine what border of screen intersection meets
        Vector2 leftIntersection = cameraPosition + new Vector2(-halfWidth, -halfHeight) / direction;
        Vector2 rightIntersection = cameraPosition + new Vector2(halfWidth, halfHeight) / direction;
        Vector2 topIntersection = cameraPosition + new Vector2(-halfWidth, halfHeight) / direction;
        Vector2 bottomIntersection = cameraPosition + new Vector2(halfWidth, -halfHeight) / direction;

        //Offset so that sprite instantiates off camera by margin offset value
        //If Right
        if (direction.x > 0 && direction.y >= 0)
        {
            intersectionPoint.x += marginOffset;
        }
        //If left
        else if (direction.x < 0 && direction.y >= 0)
        {
            intersectionPoint.x -= marginOffset;
        }
        //If top
        else if (direction.x >= 0 && direction.y > 0)
        {
            intersectionPoint.y += marginOffset;
        }
        //If bottom
        else if (direction.x >= 0 && direction.y < 0)
        {
            intersectionPoint.y -= marginOffset;
        }

        return intersectionPoint;
    }

    public IEnumerator SpawnEnemies()
    {
        while (CheckEnemyCount())
        {
            System.Random rnd = new System.Random();
            int type = rnd.Next(0, prefab.Length);
            if (wave == 0)
            {
                type %= 3;
            }
            if(wave == 1)
            {
                type = (type % 3) + 3;
            }
            if(wave == 2)
            {
                type = (type % 3) + 6;
            }
            Vector3 spawnPosition = getSpawnLocation();
            Vector3 spawnScale = new Vector3(10f, 10f, 1f);
            Instantiate(prefab[type], spawnPosition, transform.rotation);
            prefab[type].transform.localScale = spawnScale;
            enemySpawned++;
            enemyCount++;
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
