using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    public Text HighScoreEndlessRun1;
    public Text HighScoreEndlessRun2;
    public Text HighScoreEndlessRun3;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreEndlessRun1.text = PlayerPrefs.GetFloat("HighScore").ToString();
        HighScoreEndlessRun2.text = PlayerPrefs.GetFloat("HighScore2").ToString();
        HighScoreEndlessRun3.text = PlayerPrefs.GetFloat("HighScore3").ToString();
    }
}
