using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StoryModeMenu : MonoBehaviour
{
    public string backToMain;
  //  public Sprite[] button_score_2, button_score_3, button_score_4, button_score_5 , button_score_6, button_score_7;
    public Button level02Button, level03Button, level04Button, level05Button, level06Button, level07Button;
    int levelPassed;

    private void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;
        level05Button.interactable = false;
        level06Button.interactable = false;
        level06Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                level02Button.interactable = true;
   //             level02Button.gameObject.GetComponent<Image>().sprite = button_score_2;

                break;
            case 2:
                level02Button.interactable = true;
                level03Button.interactable = true;
                break;
            case 3:
                level02Button.interactable = true;
                level03Button.interactable = true;
                level04Button.interactable = true;
                break;
            case 4:
                level02Button.interactable = true;
                level03Button.interactable = true;
                level04Button.interactable = true;
                level05Button.interactable = true;
                break;
            case 5:
                level02Button.interactable = true;
                level03Button.interactable = true;
                level04Button.interactable = true;
                level05Button.interactable = true;
                level06Button.interactable = true;
                break;
            case 6:
                level02Button.interactable = true;
                level03Button.interactable = true;
                level04Button.interactable = true;
                level05Button.interactable = true;
                level06Button.interactable = true;
                level07Button.interactable = true;
                break;
        }


    }

    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void resetPrefs()
    {
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;
        level05Button.interactable = false;
        level06Button.interactable = false;
        level06Button.interactable = false;
        PlayerPrefs.DeleteAll();
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
