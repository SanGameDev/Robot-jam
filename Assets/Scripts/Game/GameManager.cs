using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    private int waitTime = 10;
    private int score;

    [HideInInspector] public bool isGameOver;

    private void Start()
    {
        isGameOver = false;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<SpawnManager>().StartSpawn();
        if(waitTime > 1)
            waitTime--;
        if (!isGameOver)  
            StartCoroutine(StartGame());
    }

    public void GameOver()
    {
        if (score > gameData.highScore)
        {
            gameData.highScore = score;
            isGameOver = true;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
