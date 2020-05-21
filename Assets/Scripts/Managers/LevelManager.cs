using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int nextSceneLoad;


    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if(nextSceneLoad > PlayerPrefs.GetInt("levelPassed"))
            {
                PlayerPrefs.SetInt("levelPassed", nextSceneLoad);
            }
        }
    }

    
}

