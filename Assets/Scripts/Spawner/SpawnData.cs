using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "Scriptable Objects/SpawnData")]
public class SpawnData : ScriptableObject
{
    public GameObject enemyPrefab;

    public int areasToSpawn;
    public int enemiesToSpawn;
}
