using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generation : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Tooltip("ProceduralPath")] public Tilemap tilemap;
    [Tooltip("Extra Jungle Rule Tiles")] public TileBase tile;
    [Tooltip("Width of map")]
    public int width;
    [Tooltip("Height of map")]
    public int height;
    [Tooltip("Interval of points 1-10")]
    public int interval;
    public bool isRandomWalk;
    public int xOffset;
    public int yOffset;
   
    
    void Start()
    {
        ClearMap();
        GenerateMap();
   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ClearMap();
            GenerateMap();
        }
    }

    public void GenerateMap()
    {
        ClearMap();
        int[,] map = new int[width, height];
        float seed=Time.time;
        map = GenerateArray(width, height, true);

        if (isRandomWalk)
        {
            map = RandomWalkTopSmoothed(map, seed, interval);
        }
        else
        {
            map = PerlinNoise(map, seed);
        }
        RenderMap(map);

    }
    public void ClearMap()
    {
        tilemap.ClearAllTiles();
    }

    public int[,] RandomWalkTopSmoothed(int[,] map, float seed, int minSectionWidth)
    {
     
        System.Random rand = new System.Random(seed.GetHashCode());
 
      
        int lastHeight = Random.Range(0, map.GetUpperBound(1));
 
      
        int nextMove = 0;
    
        int sectionWidth = 0;
 
  
        for (int x = 0; x <= map.GetUpperBound(0); x++)
        {
     
            nextMove = rand.Next(2);
 
            if (nextMove == 0 && lastHeight > 0 && sectionWidth > minSectionWidth)
            {
                lastHeight--;
                sectionWidth = 0;
            }
            else if (nextMove == 1 && lastHeight < map.GetUpperBound(1) && sectionWidth > minSectionWidth)
            {
                lastHeight++;
                sectionWidth = 0;
            }
  
            sectionWidth++;
 
            for (int y = lastHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }
 
        return map;
    }
    public static int[,] PerlinNoise(int[,] map, float seed)
    {
        int newPoint;
        //Used to reduced the position of the perlin point
        float reduction = 0.5f;
        //Create the perlin
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(x, seed) - reduction) * map.GetUpperBound(1));

            //Make sure the noise starts near the halfway point of the height
            newPoint += (map.GetUpperBound(1) / 2); 
            for (int y = newPoint; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }
        return map;
    }
    public void UpdateMap(int[,] map, Tilemap tilemap) 
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {

                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }
    public void RenderMap(int[,] map)
    {
   
        tilemap.ClearAllTiles(); 
    
        for (int x = 0; x < map.GetUpperBound(0) ; x++) 
        {
        
            for (int y = 0; y < map.GetUpperBound(1); y++) 
            {
    
                if (map[x, y] == 1) 
                {
                    tilemap.SetTile(new Vector3Int(x+xOffset, y+yOffset, 0), tile); 
                    
                }
            }
        }
    }
    
    public static int[,] GenerateArray(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }
}
