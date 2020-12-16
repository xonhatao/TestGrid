using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//The class implements the Grid generation from (a) 2d integer array
public class TilemapSet : MonoBehaviour
{
    public int col, rows;    
    public GameObject tilePrefab;
    public Sprite[] sprites;
    private int[,] Grid;

    int[,] testGrid = {
    {-1,-1,2,2,2,2,2,2,2,2,-1,-1},
    {2,2,1,1,1,1,1,1,1,1,2,2},
    {2,1,0,0,1,1,1,1,1,0,0,2},
    {2,1,0,0,0,0,0,0,0,0,0,2},
    {0,0,0,0,0,0,0,0,0,0,0,0},
    {2,0,0,0,0,1,1,1,0,0,0,2},
    {2,0,0,0,1,1,1,1,0,0,0,2},
    {2,2,2,1,1,1,1,1,1,1,2,2},
    {-1,-1,-1,1,0,1,0,1,-1,1,2,1}
    };


    //Grid variables
    public Tilemap tilemapUnder;
    public Tilemap tilemapUpper;
    public Tilemap tilemapBlock;
    //Test Tile
    //Under floor tile
    public Tile tileFloorUnder;
    //Upper floor tile
    public Tile tileFloorUpper;
    //Array of Block tile, in Google Drive is a collection of blocks
    public Tile[] tileFloorBlock;

    Vector3Int startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        //IF the start position is (0,0) in Worldmap THEN the startingPoint of Tilemap Grid must be moved up left.
        startingPoint = new Vector3Int((int) -col / 2, (int) rows/2, 0);
        //Init
        Grid = new int[rows, col];

        //Test from written array
        GenerateGrid(testGrid);
    }
    /// <summary>
    /// Generate 3 tilemap from input array, all 3 for terrain sites.
    /// Notice the position of array and position of real grid is different, one is from top left and another is from bottom left
    /// </summary>
    /// <param name="inputGrid">The input array</param>
    void GenerateGrid(int[,] inputGrid) {

        //Terrain generation from inputGrid
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                switch (inputGrid[i,j])
                {
                    //0 is for underground tiles
                    case 0: tilemapUnder.SetTile(new Vector3Int(j, -i, 0) + startingPoint, tileFloorUnder); break;
                    //1 is for upperground tiles
                    case 1: tilemapUpper.SetTile(new Vector3Int(j, -i, 0) + startingPoint, tileFloorUpper); break;
                    //2 is for Block tiles
                    case 2: tilemapBlock.SetTile(new Vector3Int(j, -i, 0) + startingPoint, tileFloorBlock[Random.Range(0,tileFloorBlock.Length)]); break;
                }
               
            }
        }

        //TODO
        //Decorations
        //The same thing as above, a new array only for decorations
        //Background
        //Randomly spawn?
    }

}
