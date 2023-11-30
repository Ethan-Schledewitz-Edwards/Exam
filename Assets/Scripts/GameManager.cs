using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        ScoreManager.Instance.GameStart();
        InputManager.GameMode();
        PlatformSpawner.Instance.BeginGen();
    }

    public void PlayerDied()
    {
        ScoreManager.Instance.GameOver();
        PlatformSpawner.Instance.GameOver();
        UIManager.Instance.GameOver();
    }
}
