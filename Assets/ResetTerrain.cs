using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTerrain : MonoBehaviour
{
    public Terrain terrain;
    private float[,] originalHeights;

    private void OnApplicationQuit()
    {
        terrain.terrainData.SetHeights(0, 0, originalHeights);
    }

    private void Start()
    {
        originalHeights = terrain.terrainData.GetHeights(
            0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        Debug.Log("heights set");
    }
}