using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public GameObject text;
    public bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 1;
                text.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                paused = false;
                text.SetActive(true);
            }
            //SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the current scene by loading it again
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void levelselect()
    {
        SceneManager.LoadScene(1);
    }
    public void resume()
    {
        paused = true;
        Time.timeScale = 1;
        text.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
}
