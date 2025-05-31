using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  
    public static GameManager instance;

    public Text scoreText; 
    

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
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText();
        Debug.Log("Score: " + score);
    }

    
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("unable to show score");
        }
    }
}