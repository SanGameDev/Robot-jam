using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData spawnData;
    public List<GameObject> spawnAreas;

    public void StartSpawn() 
    {
        for (int i = 0; i < spawnData.areasToSpawn; i++)
        {
            RandomizeSpawn();
        }
    }

    public void RandomizeSpawn()
    {
        int area = Random.Range(1, spawnAreas.Count);
        Debug.Log("Spawning in area " + area);
        spawnAreas[area].GetComponent<SpawnArea>()
        .StartCoroutine(spawnAreas[area].GetComponent<SpawnArea>()
        .Spawn(spawnData.enemyPrefab, spawnData.enemiesToSpawn));
    }
}
