using UnityEngine;
using UnityEngine.SceneManagement;
public class FruitAppears : MonoBehaviour
{    
    public AudioSource audioSource; // Assign in inspector
    public GameObject objectToAppear; // Assign in inspector
    public float time = 4;
    public int scene = 0;
    void awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
            return;
        }

        if (objectToAppear == null)
        {
            Debug.LogError("Object to appear is not assigned!");
            return;
        }

        // Start playing the sound
        audioSource.Play();

        // Initially hide the object
        objectToAppear.SetActive(false);

        // Call the method to show the object after 4 seconds
        Invoke("ShowObject", time);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            audioSource.Stop();
            SceneManager.LoadScene(scene);
        }
    }
    void ShowObject()
    {
        objectToAppear.SetActive(true);
    }
    public void nextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}