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
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            theScoreManager.gameObject.SetActive(false);
            thePlayer.gameObject.SetActive(false);
            theDeathMenu.gameObject.SetActive(true);
        }
        
    }
}
