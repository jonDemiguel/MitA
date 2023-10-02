using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase groundTile;
    public int chunkSize = 300; // Adjusted chunk size.
    public int bufferDistance = 3; // Adjusted buffer distance.

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
        int gridRadius = 3; // Grid of 7x7 chunks, so radius is 3.

        for (int x = playerChunk.x - gridRadius; x <= playerChunk.x + gridRadius; x++)
        {
            for (int y = playerChunk.y - gridRadius; y <= playerChunk.y + gridRadius; y++)
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
        float chunkSizeX = (float)chunkSize / tilemap.tileAnchor.x; // Cast to float for division.
        float chunkSizeY = (float)chunkSize / tilemap.tileAnchor.y; // Cast to float for division.

        for (int x = 0; x < chunkSizeX; x++)
        {
            for (int y = 0; y < chunkSizeY; y++)
            {
                // Calculate the world position of the current tile in the chunk.
                Vector3Int tilePosition = new Vector3Int(startX + x, startY + y, 0);

                // Create a checkerboard pattern.
                bool isEvenTile = ((int)x + (int)y) % 2 == 0;

                if (isEvenTile)
                {
                    chunkTilemap.SetTile(tilePosition, groundTile);
                }
                else
                {
                    // Set other tiles here as needed.
                }
            }
        }
    }
}
