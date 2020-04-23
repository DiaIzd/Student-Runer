using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string next;
    public string backToMain;


    public void NextLevels()
    {
        SceneManager.LoadScene(next);
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
