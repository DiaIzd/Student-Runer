using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneScript : MonoBehaviour
{
    public string playGameLevel;
    public string mainMenuScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
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
