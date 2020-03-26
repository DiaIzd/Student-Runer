using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreMenager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public double scoreCounter;
    public double highScoreCounter;

    public float PointPerSecond;

    public bool isScoring;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoring)
        {
            float scoreTemp = PointPerSecond * Time.deltaTime;
            scoreTemp = Mathf.Floor(scoreTemp);
            scoreCounter += scoreTemp;
            if(highScoreCounter<scoreCounter) highScoreCounter = scoreCounter;


            scoreText.text = "Score: " + scoreCounter.ToString();
            highScoreText.text = "High Score: " + highScoreCounter;
        }
    }
}
