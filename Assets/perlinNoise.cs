using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGenerator : MonoBehaviour
{
    public int width = 256;  // Width of the map
    public int height = 256; // Height of the map
    public float scale = 20f; // Scale of the noise map

    public bool randomizeOffset = true; // Option to randomize the offset
    public float randomRange = 1000f; // Range for randomization

    private void Start()
    {
        GenerateNoiseMap();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        float xOffset = 0f;
        float yOffset = 0f;

        if (randomizeOffset)
        {
            // Randomly offset the noise to create different results
            xOffset = Random.Range(-randomRange, randomRange);
            yOffset = Random.Range(-randomRange, randomRange);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = ((float)x / width) * scale + xOffset;
                float yCoord = ((float)y / height) * scale + yOffset;
                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

                // You can map the noise values to colors here.
                // For example, create gradients for different terrain types.

                Color pixelColor = new Color(perlinValue, perlinValue, perlinValue);
                texture.SetPixel(x, y, pixelColor);
            }
        }

        texture.Apply(); // Apply the changes to the texture

        return texture;
    }

    void GenerateNoiseMap()
    {
        // This part is for generating the noise map data, which you can use for other purposes.
        float[,] noiseMap = new float[width, height];

        float xOffset = 0f;
        float yOffset = 0f;

        if (randomizeOffset)
        {
            // Randomly offset the noise to create different results
            xOffset = Random.Range(-randomRange, randomRange);
            yOffset = Random.Range(-randomRange, randomRange);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = ((float)x / width) * scale + xOffset;
                float yCoord = ((float)y / height) * scale + yOffset;
                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
                noiseMap[x, y] = perlinValue;
            }
        }

        // Now you have a 2D array 'noiseMap' containing your Perlin noise values.
        // You can use these values to generate terrain or other features in your game.
    }
}
