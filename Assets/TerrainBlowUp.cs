using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBlowUp : MonoBehaviour
{
    public Terrain TerrainMain;
    public GameObject plasma;
    public GameObject spaceships;
    int posX;
    int posY;

    int size = 100;
    float newHeight = 0f;
    int offset;
    float[,] heights;

    // Start is called before the first frame update
    void Start()
    {
        
        int res = TerrainMain.terrainData.heightmapResolution;

        Vector3 tempCoord = (transform.position - TerrainMain.gameObject.transform.position);
        Vector3 coord;
        coord.x = tempCoord.x / TerrainMain.terrainData.size.x;
        coord.y = tempCoord.y / TerrainMain.terrainData.size.y;
        coord.z = tempCoord.z / TerrainMain.terrainData.size.z;

        posX = (int)(coord.x * res);
        posY = (int)(coord.z * res);

        offset = size / 2;

        heights = TerrainMain.terrainData.GetHeights(posX - offset, posY - offset, size, size);
        
        for(int x = 0; x < size; x++)
        {
            for(int y = 0; y < size; y++)
            {
                heights[x, y] = newHeight;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BlowTerrain()
    {
        TerrainMain.terrainData.SetHeights(posX - offset, posY - offset, heights);
    }
}
