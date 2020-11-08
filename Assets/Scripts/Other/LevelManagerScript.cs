using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public void LoadMainScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("End Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
