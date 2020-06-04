using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int nextSceneLoad;


    private void Start()
    {
        nextSceneLoad = int.Parse(SceneManager.GetActiveScene().name.Substring(5)) + 2;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //at end of level saving level count if it's higher
        if (collision.gameObject.tag == "Player")
        {
            if (nextSceneLoad > PlayerPrefs.GetInt("levelPassed"))
            {
                PlayerPrefs.SetInt("levelPassed", nextSceneLoad);
                PlayerPrefs.Save();
            }
        }
    }

    
}

