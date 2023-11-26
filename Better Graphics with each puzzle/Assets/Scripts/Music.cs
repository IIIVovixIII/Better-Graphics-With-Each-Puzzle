using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music instance;

    public AudioSource music;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        music = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the desired button is pressed (change "P" to your desired button)
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic(); // Call the function to toggle music on/off
        }
    }

    void ToggleMusic()
    {
        if (music.isPlaying)
        {
            music.Pause(); // If music is playing, pause it
        }
        else
        {
            music.UnPause(); // If music is paused, unpause it
        }
    }

    public void PlayMusic()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
    }

    public void StopMusic()
    {
        music.Stop();
    }
}
