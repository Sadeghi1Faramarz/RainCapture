using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public static bool isGameOver = false;

    public GameObject winScreenPanel; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isGameOver = false;
        Time.timeScale = 1f; 

        if (winScreenPanel != null)
        {
            winScreenPanel.SetActive(false); 
        }

        score = 50; 
        UpdateScoreText();
    }

    public void AddScore(int pointsToAdd)
    {
        if (isGameOver) return;

        score += pointsToAdd;
        if (score > 100)
        {
            score = 100;
        }
        UpdateScoreText();
        Debug.Log("Score: " + score + " (+" + pointsToAdd + ")");

        if (score >= 100)
        {
            EndGameWin();
        }
    }

    public void SubtractScore(int pointsToSubtract)
    {
        if (isGameOver) return;

        score -= pointsToSubtract;
        if (score < 0)
        {
            score = 0;
        }
        UpdateScoreText();
        Debug.Log("Score: " + score + " (-" + pointsToSubtract + ")");
    }

    void EndGameWin()
    {
        isGameOver = true;
        Debug.Log("You Win");

        if (winScreenPanel != null)
        {
            winScreenPanel.SetActive(true); 
        }

        Time.timeScale = 0f;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {

        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}