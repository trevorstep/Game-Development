using UnityEngine;

public class MapRender : MonoBehaviour
{
    [Header("Tile Prefabs")]
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject tile10;
    public GameObject tile11;
    public GameObject tile12;
    public GameObject tile13;
    public GameObject tile14;
    public GameObject tile15;
    public GameObject tile16;

    [Header("Grid Settings")]
    public int rows;
    public int columns;
    public float tileSpacing = 1.0f;
    private GameObject[,] tileArray;
    public int [,] mapData;

    void Start()
    {   
        GenerateDefaultMapData();
        mapData = GetComponent<MapData>().map4;
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
                if (row == 0 || row == rows - 1 || col == 0 || col == columns - 1)
                {
                    mapData[row, col] = 1;
                }
                else
                {
                    mapData[row, col] = 0;
                }
            }
        }
    }

    void GenerateTileArray()
    {
        tileArray = new GameObject[rows, columns];

        Vector2 startPosition = new Vector2(-columns / 2.0f * tileSpacing, -rows / 2.0f * tileSpacing);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 position = startPosition + new Vector2(col * tileSpacing, row * tileSpacing);
                GameObject tilePrefab=tile1;
                if(mapData[rows-row-1, col]==1){tilePrefab=tile2;}
                if(mapData[rows-row-1, col]==2){tilePrefab=tile3;}
                if(mapData[rows-row-1, col]==3){tilePrefab=tile4;}
                if(mapData[rows-row-1, col]==4){tilePrefab=tile5;}
                if(mapData[rows-row-1, col]==5){tilePrefab=tile6;}
                if(mapData[rows-row-1, col]==6){tilePrefab=tile7;}
                if(mapData[rows-row-1, col]==7){tilePrefab=tile8;}
                if(mapData[rows-row-1, col]==8){tilePrefab=tile9;}
                if(mapData[rows-row-1, col]==9){tilePrefab=tile10;}
                if(mapData[rows-row-1, col]==10){tilePrefab=tile11;}
                if(mapData[rows-row-1, col]==11){tilePrefab=tile12;}
                if(mapData[rows-row-1, col]==12){tilePrefab=tile13;}
                if(mapData[rows-row-1, col]==13){tilePrefab=tile14;}
                if(mapData[rows-row-1, col]==14){tilePrefab=tile15;}
                if(mapData[rows-row-1, col]==15){tilePrefab=tile16;}
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tileArray[row, col] = tile;
            }
        }

        Debug.Log("Tile array created with dimensions: " + rows + "x" + columns);
    }
}