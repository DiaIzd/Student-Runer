using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StoryModeMenu : MonoBehaviour
{
    public string backToMain;
    public Button[] lvlButtons;


    void Start()
    {
        int levelPassed = PlayerPrefs.GetInt("levelPassed");
        if (levelPassed <= 2) levelPassed = 2;
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            
           if (i + 2 > levelPassed)
             lvlButtons[i].interactable = false;

        }

    }

    public void resetPrefs()
    {
        PlayerPrefs.DeleteKey("levelPassed");
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("HighScore2");
        PlayerPrefs.DeleteKey("HighScore3");
    }




    public void QuitToMain()
    {
        SceneManager.LoadScene(backToMain);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void loadScene(int i)
    {
        string sceneName ="Level"+i;
        SceneManager.LoadScene(sceneName);
    }

    
}
