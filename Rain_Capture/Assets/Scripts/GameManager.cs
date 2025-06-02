using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

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
        score = 50; 
        UpdateScoreText();
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText();
        Debug.Log("Score: " + score + " (+" + pointsToAdd + ")");
    }

    public void SubtractScore(int pointsToSubtract)
    {
        score -= pointsToSubtract;
        // if (score < 0)
        // {
        //     score = 0;
        // }
        UpdateScoreText();
        Debug.Log("Score: " + score + " (-" + pointsToSubtract + ")");
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText UI element not assigned in GameManager.");
        }
    }
}