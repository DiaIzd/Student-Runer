using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StoryModeMenu : MonoBehaviour
{
    public string backToMain;
    public Button[] lvlButtons;


    void Start()
    {
        int levelPassed = PlayerPrefs.GetInt("LevelPassed", 2);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            lvlButtons[i].onClick.AddListener(() => { loadScene(i); });
           // if (i + 2 > levelPassed)
             //   lvlButtons[i].interactable = false;
        }

    }

    public void resetPrefs()
    {
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

    public void loadScene(int i)
    {
        string sceneName ="Level"+i;
        SceneManager.LoadScene(sceneName);
    }
}
