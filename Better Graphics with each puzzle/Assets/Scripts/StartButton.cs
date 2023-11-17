using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public int scene = 0;
    public void loadscene()
    {
        SceneManager.LoadScene(scene);
    }
}