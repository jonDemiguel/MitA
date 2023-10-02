using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap treeTilemap;
    public TileBase groundTile;
    public TileBase treeTile;

    public int mapWidth = 100;
    public int mapHeight = 100;
    public float scale = 0.1f;

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float xCoord = (float)x / mapWidth * scale;
                float yCoord = (float)y / mapHeight * scale;

                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                if (sample > 0.5f)
                {
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTile);
                }
                else
                {
                    treeTilemap.SetTile(new Vector3Int(x, y, 0), treeTile);
                }
            }
        }
    }
}
