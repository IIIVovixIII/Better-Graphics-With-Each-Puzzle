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
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                text.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                text.SetActive(false);
            }
        }
    }
}
