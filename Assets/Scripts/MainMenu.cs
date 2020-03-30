using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;

    [System.Obsolete]
    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
