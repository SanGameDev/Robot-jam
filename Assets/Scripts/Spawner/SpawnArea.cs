using System.Collections;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public IEnumerator Spawn(GameObject enemy, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(enemy, transform.position + GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-2, 2);
        float z = Random.Range(-2, 2);
        return new Vector3(x, 0, z);
    }
}
