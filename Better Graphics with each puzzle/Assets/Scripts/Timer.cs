using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro text object

    private const string timerKey = "MyTimer";
    public float timer;

    void Start()
    {
        // Load the timer from PlayerPrefs when the scene starts
        timer = PlayerPrefs.GetFloat(timerKey, 0f);
        Debug.Log("Current Timer: " + timer);

        // Start counting time
        InvokeRepeating("IncreaseTimer", 1f, 1f);
    }

    void IncreaseTimer()
    {
        timer++;
        UpdateTimerText(); // Update the timer text on each increment

        // Save the updated timer to PlayerPrefs
        PlayerPrefs.SetFloat(timerKey, timer);
        PlayerPrefs.Save();
    }

    void UpdateTimerText()
    {
        // Update the TextMeshPro text object with the timer value
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F0"); // F0 for displaying whole numbers
        }
    }

    void OnApplicationQuit()
    {
        // Reset the timer when the application is about to quit (game closes)
        ResetTimer();
    }

    void ResetTimer()
    {
        timer = 0f;
        PlayerPrefs.SetFloat(timerKey, timer);
        PlayerPrefs.Save();
        Debug.Log("Timer reset to zero.");
    }
}
