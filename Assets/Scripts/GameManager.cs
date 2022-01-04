using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    private static GameManager _instance;
    
    private GameObject _player;
    private int gameScore;
    private bool _isGameOver;

   void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        _player = GameObject.FindWithTag("Player");
        gameScore = 0;
        _isGameOver = false;
    }

    public void AddGameScore(int score)
    {
        gameScore += score;
        UI.Instance.UpdateScoreText(gameScore);
    }

    public void GameOver()
    {
        UI.Instance.ShowGameOverPanel();
        _isGameOver = true;
    }
    
    public GameObject Player => _player;
    public bool IsGameOver => _isGameOver;
}
