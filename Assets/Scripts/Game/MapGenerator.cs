using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth, mapHeight;
    public float noiseScale;
    public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawnNoiseMap(noiseMap);
    }
}
