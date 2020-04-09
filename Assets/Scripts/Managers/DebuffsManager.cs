using System.Collections;
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
            //kebab
            if (clearDebuffs)
            {
                Debug.Log(theStudent.normalSpeed);
                ClearDebuffs();
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


                if (debuffLenghtCounter <= 0)
                {
                    ClearDebuffs();
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


        if (slow)
            theStudent.normalSpeed = theStudent.m_speed;
        debuffActive = true;
    }

    private void ClearDebuffs()
    {
        debuffLenghtCounter = 0;
        debuffActive = false;
        theStudent.m_speed = theStudent.normalSpeed;
    }
}