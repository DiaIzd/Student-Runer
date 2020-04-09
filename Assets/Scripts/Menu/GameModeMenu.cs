using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenu : MonoBehaviour
{
    public string playStoryMode;
    public string playEndlessRun;
    public string backMainMenu;

    public void StoryMode()
    {
        SceneManager.LoadScene(playStoryMode);
    }

    public void EndlessRun()
    {
        SceneManager.LoadScene(playEndlessRun);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(backMainMenu);
    }
}
