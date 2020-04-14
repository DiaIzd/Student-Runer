using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour
{

    public bool mushroom;
    public bool slowDebuff;
    public bool clearDebuffs;
    //  public bool safeMode;

    public float debuffLenght;

    private DebuffsManager theDebuffsManager;

    // Start is called before the first frame update
    void Start()
    {
        theDebuffsManager = FindObjectOfType<DebuffsManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            theDebuffsManager.ActivateDebuff(slowDebuff, clearDebuffs, mushroom, /*safeMode,*/ debuffLenght);

        }
        gameObject.SetActive(false);
    }
}
