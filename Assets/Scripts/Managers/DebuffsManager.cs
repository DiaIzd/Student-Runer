﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffsManager : MonoBehaviour
{

    private bool slowDebuff;
  //  private bool mushroom;
    private bool clearDebuffs;
    // private bool safeMode;

    private bool debuffActive;

    private float debuffLenghtCounter;


    private Student theStudent;
    //  private PlatformGenerator thePlatformGenerator;

  //  private float normalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        theStudent = FindObjectOfType<Student>();
        //   thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debuffActive)
        {

            if (clearDebuffs)
            {
                ClearDebuffs();
                Debug.Log("Wszedlem jak chuj w kebaba");
            }
            else
            {

                debuffLenghtCounter -= Time.deltaTime;


                //Joint
                if (slowDebuff)
                {
                    theStudent.m_speed = theStudent.normalSpeed / 2.0f;
                    Debug.Log(theStudent.normalSpeed);
                }
                //Kebab


                if (debuffLenghtCounter <= 0)
                {

                    debuffActive = false;
                    theStudent.m_speed = theStudent.normalSpeed;

                }

                
            }
        }
        

    }


    public void ActivateDebuff( bool slow, bool clear, /*bool high,*/ /*bool safe,*/ float time)
    {
        slowDebuff = slow;
        clearDebuffs = clear;
        // mushroom = high;
        //    safeMode = safe;
        debuffLenghtCounter = time;


        theStudent.normalSpeed = theStudent.m_speed;
        debuffActive = true;
    }

    private void ClearDebuffs()
    {

        debuffActive = false;
        theStudent.m_speed = theStudent.normalSpeed;
    }
}