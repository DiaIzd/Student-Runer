using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameModeMenu;
    public string highscoresScene;
    public string optionsMenu;

    public void GameMode()
    {
        SceneManager.LoadScene(gameModeMenu);
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
