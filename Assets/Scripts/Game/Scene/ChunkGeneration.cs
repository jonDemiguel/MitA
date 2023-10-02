using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase groundTile;
    public int chunkSize = 100;
    public int bufferDistance = 1; // Number of chunks to keep around the player.

    private Transform player;
    private Vector2Int currentPlayerChunk;
    private Dictionary<Vector2Int, Tilemap> loadedChunks = new Dictionary<Vector2Int, Tilemap>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the player's current chunk based on their position.
        Vector2Int newPlayerChunk = new Vector2Int(
            Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.y / chunkSize)
        );

        // Check if the player has moved to a new chunk.
        if (newPlayerChunk != currentPlayerChunk)
        {
            currentPlayerChunk = newPlayerChunk;

            // Load chunks around the player's current position.
            LoadChunksAroundPlayer(currentPlayerChunk);
        }
    }

    private void LoadChunksAroundPlayer(Vector2Int playerChunk)
    {
        for (int x = playerChunk.x - bufferDistance; x <= playerChunk.x + bufferDistance; x++)
        {
            for (int y = playerChunk.y - bufferDistance; y <= playerChunk.y + bufferDistance; y++)
            {
                Vector2Int chunkPosition = new Vector2Int(x, y);

                // Check if the chunk is already loaded.
                if (!loadedChunks.ContainsKey(chunkPosition))
                {
                    // Create a new GameObject for the chunk.
                    GameObject chunkGameObject = new GameObject("Chunk_" + x + "_" + y);
                    chunkGameObject.transform.parent = transform; // Parent it to the ChunkManager.

                    // Create a new Tilemap for the chunk.
                    Tilemap newChunkTilemap = chunkGameObject.AddComponent<Tilemap>();
                    TilemapRenderer tilemapRenderer = chunkGameObject.AddComponent<TilemapRenderer>();
                    tilemapRenderer.sortingOrder = -x; // Adjust sorting order for proper layering.

                    // Position the Tilemap.
                    chunkGameObject.transform.position = new Vector3(x * chunkSize, y * chunkSize, 0);

                    // Generate and populate the chunk with tiles.
                    GenerateChunk(newChunkTilemap, x * chunkSize, y * chunkSize);

                    // Add the loaded chunk to the dictionary.
                    loadedChunks.Add(chunkPosition, newChunkTilemap);
                }
            }
        }
    }
    
    
    private void GenerateChunk(Tilemap chunkTilemap, int startX, int startY)
    {
        // Define the size of the chunk (number of tiles in X and Y directions).
        int chunkSizeX = 10;
        int chunkSizeY = 10;

        for (int x = 0; x < chunkSizeX; x++)
        {
            for (int y = 0; y < chunkSizeY; y++)
            {
                // Calculate the world position of the current tile in the chunk.
                Vector3Int tilePosition = new Vector3Int(startX + x, startY + y, 0);

                // Create a checkerboard pattern.
                bool isEvenTile = (x + y) % 2 == 0;

                if (isEvenTile)
                {
                    chunkTilemap.SetTile(tilePosition, groundTile);
                }
                else
                {
                    // set other tiles here as needed.
                }
            }
        }
    }

}
