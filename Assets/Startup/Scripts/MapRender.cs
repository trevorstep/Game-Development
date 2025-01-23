using UnityEngine;

public class TileArrayGenerator : MonoBehaviour
{
    [Header("Tile Prefabs")]
    public GameObject tile1; // First tile prefab
    public GameObject tile2; // Second tile prefab

    [Header("Grid Settings")]
    public int rows; // Number of rows in the grid
    public int columns; // Number of columns in the grid
    public float tileSpacing = 1.0f; // Spacing between tiles
    private GameObject[,] tileArray; // 2D array to hold the tile objects
    public int [,] mapData;

    void Start()
    {   
        GenerateDefaultMapData();
        mapData = GetComponent<MapData>().map1;
        rows = mapData.GetLength(0);
        columns = mapData.GetLength(1);
        GenerateTileArray();
    }

    void GenerateDefaultMapData()
    {
        rows = 5;
        columns = 5;
        mapData = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Set border tiles to tile2 and inner tiles to tile1
                if (row == 0 || row == rows - 1 || col == 0 || col == columns - 1)
                {
                    mapData[row, col] = 1; // Use tile2 for borders
                }
                else
                {
                    mapData[row, col] = 0; // Use tile1 for inner tiles
                }
            }
        }
    }

    void GenerateTileArray()
    {
        // Initialize the array
        tileArray = new GameObject[rows, columns];

        // Calculate the starting position of the grid
        Vector2 startPosition = new Vector2(-columns / 2.0f * tileSpacing, -rows / 2.0f * tileSpacing);

        // Loop through rows and columns to instantiate tiles based on mapData
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Determine the position of the tile
                Vector2 position = startPosition + new Vector2(col * tileSpacing, row * tileSpacing);

                // Choose a tile prefab based on mapData
                GameObject tilePrefab = mapData[rows-row-1, col] == 0 ? tile1 : tile2;

                // Instantiate the tile and set its parent to this object
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);

                // Store the tile in the array
                tileArray[row, col] = tile;
            }
        }

        Debug.Log("Tile array created with dimensions: " + rows + "x" + columns);
    }
}