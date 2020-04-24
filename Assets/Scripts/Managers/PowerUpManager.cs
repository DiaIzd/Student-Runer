using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{


    private bool speedBoost;
    private bool slowBoost;

    private bool safeMode;

    private bool powerupActive;

    private float powerupLenghtCounter;


    private Student theStudent;

    // Start is called before the first frame update
    void Start()
    {
        theStudent = FindObjectOfType<Student>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupLenghtCounter -= Time.deltaTime;
            if(safeMode && powerupLenghtCounter <= 1)
            {
                theStudent.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }
            if (powerupLenghtCounter <= 0)
            {
                theStudent.safeModeSwitch(false);
                theStudent.m_speed = theStudent.normalSpeed;
                powerupActive = false;
            }
        }
    }


    public void ActivatePowerUp(bool speed, bool safe, float time)
    {
        speedBoost = speed;
        safeMode = safe;
        powerupLenghtCounter = time;

        if (speed)
          theStudent.m_speed = theStudent.m_speed * 1.5f;

        powerupActive = true;
        if(safe)theStudent.safeModeSwitch(true);
    }
}
