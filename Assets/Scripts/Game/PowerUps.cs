using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public bool speedBoost;
    public bool safeMode;

    public float powerUpLenght;

    private PowerUpManager thePowerUpManager;

    // Start is called before the first frame update
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePowerUpManager.ActivatePowerUp(speedBoost,safeMode, powerUpLenght);
        }
        gameObject.SetActive(false);
    }
}
