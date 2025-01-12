using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    private int waitTime = 10;
    private int score;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<SpawnManager>().StartSpawn();
        if(waitTime > 1)
            waitTime--;
        StartCoroutine(StartGame());
    }

    public void GameOver()
    {
        if (score > gameData.highScore)
        {
            gameData.highScore = score;
        }

        // open ui
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
