using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public float maxTreeOffset;
    public static TreeSpawner instance;
    
    void Awake()
    {
        instance = this;
    }

    public void Spawn(TerrainData[,] dataMap)
    {
        int size = dataMap.GetLength(0);
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                if (dataMap[x, z].biome.spawnPrefabs)
                {
                    float density = dataMap[x, z].biome.density;
                    if (density > 1.0f)
                    {
                        // spawn tree
                        SpawnTree(dataMap[x, z].position, dataMap[x, z].biome.spawnablePrefabs);

                        int extraTreesToSpawn = Mathf.RoundToInt(Random.Range(1.0f, density));

                        for (int e = 0; e < extraTreesToSpawn; e++)
                        {
                            // spawn tree
                            SpawnTree(dataMap[x, z].position, dataMap[x, z].biome.spawnablePrefabs);
                        }
                    }
                    else
                    {
                        if (Random.Range(0.0f, 1.0f) < density)
                        {
                            // spawn tree
                            SpawnTree(dataMap[x, z].position, dataMap[x, z].biome.spawnablePrefabs);
                        }
                    }
                }
            }
        }
    }

    void SpawnTree(Vector3 position, GameObject[] availablePrefabs)
    {
        Vector3 truePos = new Vector3(position.x + (Random.value * maxTreeOffset), position.y, position.z);
        GameObject treeObj = Instantiate(availablePrefabs[Random.Range(0, availablePrefabs.Length)], truePos, Quaternion.identity);

        RaycastHit hit;
        
        if (Physics.Raycast(new Ray(treeObj.transform.position, Vector3.down), out hit))
        {
            treeObj.transform.position = new Vector3(hit.point.x, hit.point.y - 0.02f, hit.point.z);
        }
    }
}
