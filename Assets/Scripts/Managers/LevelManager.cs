using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    int sceneIndex, levelPassed;


    private void Start()
    {
        if (instance == null)
            instance = this;

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    public void youWin()
    {
        if (sceneIndex == 7)
            Invoke("Main Menu", 1f);
        else
        {
            if(levelPassed < sceneIndex)
            PlayerPrefs.SetInt("LevelPassed", sceneIndex);
        }
    }

    
}

