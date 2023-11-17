using UnityEngine;

public class Timer : MonoBehaviour
{
    private const string countKey = "MyCount";
    private int count;

    void Start()
    {
        // Load the count from PlayerPrefs when the scene starts
        count = PlayerPrefs.GetInt(countKey, 0);
        Debug.Log("Current Count: " + count);
    }

    void Update()
    {
        // Example: Increase count when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseCount();
        }
    }

    void IncreaseCount()
    {
        count++;
        Debug.Log("Count increased to: " + count);

        // Save the updated count to PlayerPrefs
        PlayerPrefs.SetInt(countKey, count);
        PlayerPrefs.Save();
    }

    // This method can be used to reset the count if needed
    public void ResetCount()
    {
        count = 0;
        PlayerPrefs.SetInt(countKey, count);
        PlayerPrefs.Save();
        Debug.Log("Count reset to zero.");
    }

    // Clear the PlayerPrefs data (for testing or when needed)
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs data cleared.");
    }

    void OnDestroy()
    {
        // Save count when the script is destroyed or the scene changes
        PlayerPrefs.SetInt(countKey, count);
        PlayerPrefs.Save();
    }
}
