using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    public string highscoresScene;
    public string optionsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }
    public void SeeHighScore()
    {
        SceneManager.LoadScene(highscoresScene);
    }

    public void Options()
    {
        SceneManager.LoadScene(optionsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
