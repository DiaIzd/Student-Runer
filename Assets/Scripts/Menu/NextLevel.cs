using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string level;

    public void Level()
    {
        SceneManager.LoadScene(level);
    }


}