using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string backToMain;
    public string storyModeMenu;

    public void StoryMode()
    {
        SceneManager.LoadScene(storyModeMenu);
    }



    public void QuitToMain()
    {
        SceneManager.LoadScene(backToMain);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
