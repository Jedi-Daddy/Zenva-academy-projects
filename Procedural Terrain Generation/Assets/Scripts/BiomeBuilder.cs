using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeBuilder : MonoBehaviour
{
    public BiomeRow[] biomesRows;

    public static BiomeBuilder instance;
    void Awake()
    {
        instance = this;
    }

    public Texture2D BuildTexture(TerrainType[,] heatMapTypes, TerrainType[,] moistureMapTypes)
    {
        return null;
    }
}

[System.Serializable]
public class BiomeRow
{
    public Biome[] biomes;
}

[System.Serializable]
public class Biome
{
    public string name;
    public Color color;
}