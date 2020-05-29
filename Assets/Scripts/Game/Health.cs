using JetBrains.Annotations;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameManager gameManager;


    public SpriteRenderer sr;
    public Image[] hearts;
    public Sprite heart;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = heart;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (health == 0)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
            
            

        }
        
    }

   
}
