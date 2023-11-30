using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private TextMeshProUGUI _mainMenuBest;
    [SerializeField] private TextMeshProUGUI _gameOverScore;
    [SerializeField] private TextMeshProUGUI _gameOverBest;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _mainMenuPanel.SetActive(true);
        _gameOverPanel.SetActive(false);

        InputManager.UIMode();
    }

    public void GameStart()
    {
        _mainMenuPanel.SetActive(false);
        _gameOverPanel.SetActive(false);

        GameManager.Instance.StartGame();
    }

    public void GameOver()
    {
        _mainMenuPanel.SetActive(false);
        _gameOverPanel.SetActive(true);

        ScoreManager.Instance.GameOver();
        _gameOverScore.text = ScoreManager.Instance.CurrentScore.ToString();
        _gameOverBest.text = ScoreManager.Instance.CurrentHighScore.ToString();

        InputManager.UIMode();
    }

    public void ResetButton()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
