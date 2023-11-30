using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentHighScore { get; private set; }
    public int CurrentScore { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        CurrentScore = 0;
    }

    public void GameOver()
    {
        if (CurrentScore > CurrentHighScore)
            CurrentHighScore = CurrentScore;
    }

    public void IncrementScore()
    {
        CurrentScore++;
    }
}
