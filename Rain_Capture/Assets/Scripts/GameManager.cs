using UnityEngine;
using TMPro; // Required for TextMeshProUGUI

public class GameManager : MonoBehaviour
{
    // Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance;

    // Public variable to link to the TextMeshProUGUI element in the Inspector.
    public TextMeshProUGUI scoreText;

    // Private variable to store the current score.
    private int score = 0;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        // Singleton pattern implementation:
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this:
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize score to 0 at the start of the game
        score = 0;
        // Update the score display
        UpdateScoreText();
    }

    // Public method to add points to the score
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd; // Add the given points to the current score
        UpdateScoreText();    // Update the score display
        Debug.Log("Score: " + score); // Log the new score to the console
    }

    // Method to update the score text on the UI
    void UpdateScoreText()
    {
        // Check if the scoreText reference is set
        if (scoreText != null)
        {
            // Update the text property of the TextMeshProUGUI component
            scoreText.text = "Score: " + score;
        }
        else
        {
            // Log a warning if the scoreText reference is not set
            Debug.LogWarning("unable to show score");
        }
    }
}