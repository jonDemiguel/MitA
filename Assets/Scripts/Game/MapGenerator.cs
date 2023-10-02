using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Map variables
    public int mapWidth, mapHeight;
    public float noiseScale;
    public bool autoUpdate;
    public int octaves;
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;


    // Generate a noise map
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawnNoiseMap(noiseMap);
    }

    // Make sure the variables are in a valid range
    void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}
