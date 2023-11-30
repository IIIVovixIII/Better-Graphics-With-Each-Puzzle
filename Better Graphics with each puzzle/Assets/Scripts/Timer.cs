using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Import this for scene management

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro text object
    public TextMeshProUGUI highScoreText; // Reference to display the high score

    private const string timerKey = "MyTimer";
    private const string highScoreKey = "HighScore";
    public float timer;
    private bool isTimerRunning = true; // Flag to check if the timer is running

    void Start()
    {
        // Load the timer from PlayerPrefs when the scene starts
        timer = PlayerPrefs.GetFloat(timerKey, 0f);
        Debug.Log("Current Timer: " + timer);

        // Start counting time
        InvokeRepeating("IncreaseTimer", 1f, 1f);
    }

    void Update()
    {
        // Check if the current scene is Main Menu
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            StopTimerAndCheckHighScore();
        }
    }

    void IncreaseTimer()
    {
        if (isTimerRunning)
        {
            timer++;
            UpdateTimerText(); // Update the timer text on each increment
        }
    }

    void UpdateTimerText()
    {
        // Update the TextMeshPro text object with the timer value
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F0"); // F0 for displaying whole numbers
        }
    }

    public void StopTimerAndCheckHighScore()
    {
        isTimerRunning = false; // Stop the timer

        float highScore = PlayerPrefs.GetFloat(highScoreKey, float.MaxValue);

        if (timer < highScore) // Check if the current timer is a new high score
        {
            PlayerPrefs.SetFloat(highScoreKey, timer);
            PlayerPrefs.Save();
            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + timer.ToString("F0");
            }
            Debug.Log("New High Score: " + timer);
        }

        // Reset the timer for the next game
        ResetTimer();
    }

    void ResetTimer()
    {
        timer = 0f;
        PlayerPrefs.SetFloat(timerKey, timer);
        PlayerPrefs.Save();
        Debug.Log("Timer reset to zero.");
    }

    // Call this method when starting a new game
    public void StartNewGame()
    {
        isTimerRunning = true;
        ResetTimer();
    }
}
