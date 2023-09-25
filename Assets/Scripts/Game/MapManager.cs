using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    // Set the width, height and color of the map
    [SerializeField] private int width = 80, height = 45;
    [SerializeField] private Color32 darkColor = new Color32(0, 0, 0, 0), lightColor = new Color32(255, 255, 255, 255);
    // Define the floor and wall tiles, and the floor and obstacle tilemaps
    [SerializeField] private TileBase floorTile, wallTile;
    [SerializeField] private Tilemap floorMap, obstacleMap;

    // Getter methods
    public Tilemap FloorMap { get => floorMap; }
    public Tilemap ObstacleMap { get => obstacleMap; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the center tile
        Vector3Int centerTile = new Vector3Int(width / 2, height / 2, 0);

        // Set the wall bound to be located at x = 1, y = 1, with a width of 3 and a height of 1
        BoundsInt wallBounds = new BoundsInt(new Vector3Int(1, 1, 0), new Vector3Int(3, 1, 0));

        // Iterately set the obstacle tiles
        for (int x = 0; x < wallBounds.size.x; x++)
        {
            for (int y = 0; y < wallBounds.size.y; y++)
            {
                Vector3Int wallPosition = new Vector3Int(wallBounds.min.x + x, wallBounds.min.y + y, 0);
                obstacleMap.SetTile(wallPosition, wallTile);
            }
        }


        // Set the scale of the camera
        Camera.main.orthographicSize = 20;
    }

    // Used to check if the player is in bounds of the map
    public bool InBounds(int x, int y) => 0 <= x && x < width && 0 <= y && y < height;
}
