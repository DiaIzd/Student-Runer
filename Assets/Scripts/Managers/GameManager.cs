using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;


    public ScoreMenager theScoreManager;
    public Student thePlayer;
    public DeathMenu theDeathMenu;


    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreMenager>();
    }


    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            theScoreManager.isScoring = false;
            setHighScore(theScoreManager.scoreCounter);
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            
            thePlayer.gameObject.SetActive(false);
            theDeathMenu.gameObject.SetActive(true);
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
}
