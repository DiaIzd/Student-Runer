using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    bool levelFinished = false;

    public ScoreManager theScoreManager;
    public Student thePlayer;
    public DeathMenu theDeathMenu;
    public NextLevel theNextLevel;


    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }


    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            offScoring();
            setHighScore(thePlayer.scoreCounter);
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            
            thePlayer.gameObject.SetActive(false);
            theDeathMenu.gameObject.SetActive(true);
        }
        
    }

    public void NextLevel()
    {
        if (levelFinished == false)
        {
            offScoring();
            setHighScore(thePlayer.scoreCounter);
            levelFinished = true;
            thePlayer.gameObject.SetActive(false);
            theNextLevel.gameObject.SetActive(true);

        }
    }

    private bool setHighScore(float scoreCounter)
    {
        if (PlayerPrefs.GetFloat("HighScore") < scoreCounter)
        {
            PlayerPrefs.SetFloat("HighScore3", PlayerPrefs.GetFloat("HighScore2"));
            PlayerPrefs.SetFloat("HighScore2", PlayerPrefs.GetFloat("HighScore"));
            PlayerPrefs.SetFloat("HighScore", scoreCounter);
            return true;
        }
        else if (PlayerPrefs.GetFloat("HighScore2") < scoreCounter)
        {
            PlayerPrefs.SetFloat("HighScore3", PlayerPrefs.GetFloat("HighScore2"));
            PlayerPrefs.SetFloat("HighScore2", scoreCounter);
            return true;
        }
        else if (PlayerPrefs.GetFloat("HighScore3") < scoreCounter)
        {
            PlayerPrefs.SetFloat("HighScore3", scoreCounter);
            return true;
        }
        return false;
    }

    private void offScoring()
    {
        try
        {
            theScoreManager.isScoring = false;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("ScoreMenager was not set in the inspector");
        }
    }
}
