﻿using System.Collections;
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
  //  private PlatformGenerator thePlatformGenerator;

    private float normalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        theStudent = FindObjectOfType<Student>();
     //   thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupLenghtCounter -= Time.deltaTime;

            if (speedBoost)
            {
                theStudent.m_speed = normalSpeed * 2.0f;
            }

            if (powerupLenghtCounter <= 0)
            {

                theStudent.m_speed = normalSpeed;
                powerupActive = false;
            }
        }
    }


    public void ActivatePowerUp(bool speed, /*bool safe,*/ float time)
    {
        speedBoost = speed;
        //    safeMode = safe;
        powerupLenghtCounter = time;


        normalSpeed = theStudent.m_speed;
        powerupActive = true;
    }
}
