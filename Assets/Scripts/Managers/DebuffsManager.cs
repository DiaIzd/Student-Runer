using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebuffsManager : MonoBehaviour
{

    private bool slowDebuff;
    private bool mushroom;
    private bool clearDebuffs;
    public float changeColorInterval = 0.1f;

    public High theHigh;
    public float highCounter = 0;

    private bool debuffActive;

    private float debuffLenghtCounter;


    private Student theStudent;

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

                if (mushroom)
                {
                    Mushroom();
                    
                }

            }
        }
        

    }


    public void ActivateDebuff( bool slow, bool clear, bool high, float time)
    {
        slowDebuff = slow;
        clearDebuffs = clear;
        mushroom = high;
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

    private void Mushroom()
    {
     //   highCounter -= Time.deltaTime;


        theHigh.gameObject.SetActive(true);
        // ChangeColor("red");

        ChangeColor();

      //  theHigh.redBackground.gameObject.SetActive(true);
      //  theHigh.blueBackground.gameObject.SetActive(true);
     //   theHigh.greenBackground.gameObject.SetActive(true);
        //    mushroom = false;

    }

    private void ChangeColor()
    {
        if (debuffActive)
        {
            if (highCounter > 2)
                highCounter = 0;
            switch (highCounter)
            {
                case 0:
                    theHigh.redBackground.gameObject.SetActive(true);
                    highCounter++;
                    theHigh.greenBackground.gameObject.SetActive(false);
                    Invoke("ChangeColor", changeColorInterval);
                    break;
                case 1:
                    theHigh.blueBackground.gameObject.SetActive(true);
                    highCounter++;
                    theHigh.redBackground.gameObject.SetActive(false);
                    Invoke("ChangeColor", changeColorInterval);
                    break;
                case 2:
                    theHigh.greenBackground.gameObject.SetActive(true);
                    highCounter++;
                    theHigh.blueBackground.gameObject.SetActive(false);
                    Invoke("ChangeColor", changeColorInterval);
                    break;
            }
        }
        else
            theHigh.gameObject.SetActive(false);

    }
}