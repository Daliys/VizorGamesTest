using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject healthImage1;
    [SerializeField] private GameObject healthImage2;
    [SerializeField] private GameObject healthImage3;
    [SerializeField] private GameObject gameOverPanel;

    public static UI Instance => _instance;
    private static UI _instance;

    void Start()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHealth(int remainsHealth)
    {
        if (remainsHealth == 2) healthImage3.SetActive(false);
        if (remainsHealth == 1) healthImage2.SetActive(false);
        if (remainsHealth == 0) healthImage1.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

public void OnButtonClickRestart()
    {
        SceneManager.LoadScene(0);
    }
}
