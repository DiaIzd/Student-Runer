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
            if (offScoring())
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
            if(offScoring())
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
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetFloat("HighScore3") + "1");
            return true;
        }
        else if (PlayerPrefs.GetFloat("HighScore2") < scoreCounter)
        {
            PlayerPrefs.SetFloat("HighScore3", PlayerPrefs.GetFloat("HighScore2"));
            PlayerPrefs.SetFloat("HighScore2", scoreCounter);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetFloat("HighScore3")+"2");
            return true;
        }
        else if (PlayerPrefs.GetFloat("HighScore3") < scoreCounter)
        {
            PlayerPrefs.SetFloat("HighScore3", scoreCounter);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetFloat("HighScore3")+"3");
            return true;
        }
        return false;
    }

    private bool offScoring()
    {
        try
        {
            theScoreManager.isScoring = false;
            thePlayer.scoreCounter = theScoreManager.scoreCounter;
            return true;
        }
        catch (NullReferenceException ex)
        {
            return false;
        }
    }
}
