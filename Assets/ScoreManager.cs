using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCounter;
    public float highScoreCounter;

    public float PointPerSecond;

    public bool isScoring;

    // Start is called before the first frame update
    void Start()
    {
        /*clearing highscores
        PlayerPrefs.SetFloat("HighScore", scoreCounter);
        PlayerPrefs.SetFloat("HighScore2", scoreCounter);
        PlayerPrefs.SetFloat("HighScore3", scoreCounter);
        */


        float highScore = PlayerPrefs.GetFloat("HighScore");
        if (highScore != 0)
        {
            highScoreCounter = highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoring)
        {
            scoreCounter += Mathf.Floor(PointPerSecond * Time.deltaTime);
            if (highScoreCounter < scoreCounter)
            {
                highScoreCounter = scoreCounter;
            }
            scoreText.text = "Score: " + scoreCounter.ToString();
            highScoreText.text = "High Score: " + highScoreCounter;
        }
    }


}
