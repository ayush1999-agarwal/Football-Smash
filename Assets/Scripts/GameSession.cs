using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] float gameSpeedUpdateFactor = 0.4f;
    [SerializeField] float currentGameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 50;
    [SerializeField] TextMeshProUGUI scoreText;

    //state variables
    [SerializeField] int gameScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        Time.timeScale = gameSpeed;
    }
    
    public void GameSpeedDec()
    {
        gameSpeed -= gameSpeedUpdateFactor;
    }

    public void GameSpeedInc()
    {
        gameSpeed += gameSpeedUpdateFactor;
    }

    public void GameSpeedOriginal()
    {
        gameSpeed = currentGameSpeed;
        gameSpeed = currentGameSpeed;
    }

    public void AddScoreToCurrent()
    {
        gameScore += pointsPerBlock;
        scoreText.text = gameScore.ToString();
    }

    public void RestartScore()
    {
        Destroy(gameObject);
    }

}
