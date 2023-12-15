using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Import this for scene management

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro text object
    public TextMeshProUGUI bestTimeText; // Reference to display the best time

    public bool[] levelsCompleted = new bool[2]; // Array to track the completion of levels 1-4
    public string[] levels = new string[2] { "Level 1", "Level 2"}; // Update with actual level names

    private const string timerKey = "MyTimer";
    private const string bestTimeKey = "BestTime"; // Changed from HighScoreKey to BestTimeKey
    private const string levelCompletedKey = "LevelCompleted"; // Key prefix for level completion
    public float bestTime = 0;

    public float timer;
    private bool isTimerRunning = true; // Flag to check if the timer is running

    void Start()
    {
        // Load the timer from PlayerPrefs when the scene starts
        timer = PlayerPrefs.GetFloat(timerKey, 0f);
        LoadLevelCompletions();
        Debug.Log("Current Timer: " + timer);
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            ResetLevelCompletions();
            SaveLevelCompletions();
            ResetTimer();
        }
        // Start counting time
        InvokeRepeating("IncreaseTimer", 1f, 1f);
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Check if the current scene is Main Menu
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            StopTimerAndCheckBestTime();
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if (currentSceneName == levels[i])
            {
                levelsCompleted[i] = true;
                PlayerPrefs.SetInt(levelCompletedKey + i, 1); // Save level completion
                PlayerPrefs.Save();
            }
        }
    }
    private void SaveLevelCompletions()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            PlayerPrefs.SetInt(levelCompletedKey + i, levelsCompleted[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }
    private void LoadLevelCompletions()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levelsCompleted[i] = PlayerPrefs.GetInt(levelCompletedKey + i, 0) == 1;
        }
    }

    private bool AreAllLevelsCompleted()
    {
        LoadLevelCompletions(); // Make sure to load the latest data
        foreach (bool levelCompleted in levelsCompleted)
        {
            if (!levelCompleted) return false;
        }
        return true;
    }
    void IncreaseTimer()
    {
        if (isTimerRunning)
        {
            timer++;
            UpdateTimerText(); // Update the timer text on each increment
            PlayerPrefs.SetFloat(timerKey, timer);
            PlayerPrefs.Save();
        }
    }

    void UpdateTimerText()
    {
        // Update the TextMeshPro text object with the timer value
        if (timerText != null)
        {
            timerText.text = "Your Time: " + timer.ToString("F0"); // F0 for displaying whole numbers
        }
    }

    public void StopTimerAndCheckBestTime()
    {
        isTimerRunning = false; // Stop the timer


        // Check if all levels are completed
        if (AreAllLevelsCompleted())
        {
            bestTime = bestTime;
            Debug.Log(bestTime);
            Debug.Log("All levels completed. Current timer: " + timer + ", Best time: " + bestTime);

            // Check if the current timer is a new best time and it's not zero
            if(bestTime == 0)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat(bestTimeKey, timer);
                PlayerPrefs.Save();
                bestTimeText.text = "Best Time: " + timer.ToString("F0");
            }
            if (timer < bestTime)
            { 
                PlayerPrefs.SetFloat(bestTimeKey, timer);
                PlayerPrefs.Save();
                bestTimeText.text = "Best Time: " + timer.ToString("F0");
                timerText.text = "Your Time: " + timer.ToString("F0"); // F0 for displaying whole numbers

                Debug.Log("New Best Time: " + timer);
            }
        }
        else
        {
            //Debug.Log("Not all levels completed. Best time not updated.");
        }
    }



    void ResetTimer()
    {
        timer = 0f;
        PlayerPrefs.SetFloat(timerKey, timer);
        PlayerPrefs.Save();
        //Debug.Log("Timer reset to zero.");
    }

    // Call this method when starting a new game
    public void StartNewGame()
    {
        isTimerRunning = true;
        ResetTimer();
    }
    private void ResetLevelCompletions()
    {
        for (int i = 0; i < levelsCompleted.Length; i++)
        {
            levelsCompleted[i] = false;
        }
    }
}
