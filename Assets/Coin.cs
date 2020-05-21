using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text scoreText;
    public Student player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.scoreCounter++;
            scoreText.text = "Score:" + player.scoreCounter;
        }
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}