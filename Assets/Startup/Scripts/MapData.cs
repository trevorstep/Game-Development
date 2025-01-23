using UnityEngine;

public class MapData : MonoBehaviour{
    public int[,] map1  =  {{1,1,1,1,1,1,1},
                            {1,0,0,0,1,0,1},
                            {1,0,0,0,1,0,1},
                            {1,0,1,1,1,0,1},
                            {1,0,0,0,0,0,0},
                            {1,1,1,1,1,1,0}};

    public int[,] map2  = {{0,0,0,1,0,1},
                            {0,0,0,1,0,1},
                            {0,1,1,1,0,1},
                            {0,0,0,0,0,0},
                            {1,1,1,1,1,0}};

    public int[,] map3  = {{0,0,0,1,0,1},
                            {0,0,0,1,0,1},
                            {0,1,1,1,0,1},
                            {0,0,0,0,0,0},
                            {1,1,1,1,1,0}};
}