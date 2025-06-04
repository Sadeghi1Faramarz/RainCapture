using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public static bool isGameOver = false;

    [Header("Game Win UI")]
    public GameObject winImageObject;

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

        if (winImageObject != null)
        {
            winImageObject.SetActive(false);
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
    }

    void EndGameWin()
    {
        isGameOver = true;

        if (winImageObject != null)
        {
            winImageObject.SetActive(true);
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
}