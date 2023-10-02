using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        // Create a new texture
        Texture2D texture = new Texture2D(width, height);

        // Set the texture to point filtering
        texture.filterMode = FilterMode.Point;

        // Set the texture to wrap around the edges
        texture.wrapMode = TextureWrapMode.Clamp;

        // Set the pixels of the texture
        texture.SetPixels(colorMap);

        // Apply the texture
        texture.Apply();

        // Return the texture
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        // Create a color map
        Color[] colorMap = new Color[width * height];
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++) 
            {
                // Set the color of each pixel based on the noise map
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }

        return TextureFromColorMap(colorMap, width, height);
    }
}
