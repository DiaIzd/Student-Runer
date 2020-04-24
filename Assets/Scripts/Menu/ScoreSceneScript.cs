using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneScript : MonoBehaviour
{
    public string gameModeMenu;
    public string mainMenuScene;

    public void GameMode()
    {
        SceneManager.LoadScene(gameModeMenu);
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
