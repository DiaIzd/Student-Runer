using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour


{

    public Transform platformGenerator;
    private Vector3 platrofmStartPoint;

    public Student thePlayer;
    private Vector3 playerStartPoint;


    // Start is called before the first frame update
    void Start()
    {
        platrofmStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerable RestartGameCo()
    {

        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platrofmStartPoint;
        thePlayer.gameObject.SetActive(true);

    }

}
