using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPuller : MonoBehaviour
{
    public GameObject[] enemies;
    List<GameObject> pooledEnemies;
    public int index;
    public GameManager gameManager;

    [SerializeField]
    private DialogManager dialogManager = null;

    public float EnemiesPropability;
    public float minDistanceBeetween = 2;
    public float maxDistanceBeetween = 2;
    public float maxHeight;
    public float minHeight;

    [SerializeField, Range(0.1f, 40)]
    private float winTime = 1;

    [SerializeField]
    private float enemiesDestroyer = -300f;

    [SerializeField]
    private Health health = null;

    [SerializeField]
    private GameObject laserBeamToBoss = null;

    [SerializeField]
    private GameObject stelarisShield = null;

    [SerializeField]
    private GameObject euShield = null;

    [SerializeField]
    private GameObject laserBeamFromBoss = null;

    [SerializeField]
    private Image flash = null;

    [SerializeField, Range(1, 10)]
    private float animationDuration = 1;

    private Coroutine laserBeam = null;

    private bool endAnimation = false;


    private void Start()
    {
        laserBeamFromBoss.SetActive(false);
        laserBeamToBoss.SetActive(false);
        euShield.SetActive(false);
        stelarisShield.SetActive(false);
        pooledEnemies = new List<GameObject>();
        Invoke("DodGenerator", 1.0f);
        Invoke("BugGenerator", 2.0f);
        Invoke("Sprint", 3.0f);
        
        //Sprint();

    }

    private void Update()
    {

        //winTime += Time.deltaTime;
        //if (winTime >= 5.0f && gameManager.gameHasEnded == false)
        //{

        //   // Time.timeScale = 0;
        //    laserBeam = StartCoroutine(Laser());



        //}

        if (winTime >= 40.0f && gameManager.gameHasEnded == false)
        {
            FindObjectOfType<GameManager>().NextLevel();
            Time.timeScale = 0;

        }

        //if (enemies[index].transform.position.x > enemiesDestroyer)
        //{
        //    Destroy(enemies[index]);
        //}
        //if (sprintHolder != null)
        //{

        //    if (sprintHolder.transform.position.y >= 0.6f)
        //    {
        //        Debug.LogWarning(sprintHolder);
        //        //float randomX = Random.Range(0.2f, 0.7f);
        //        //sprintHolder.transform. = randomX;
        //        sprintHolder.transform.position = new Vector3(0.2f, 0.6f, 0f);
        //        sprintHolder.GetComponent<Rigidbody2D>().gravityScale = 0f;

        //    }
        //}
    }

    public GameObject GetPolledEnemies(int index)
    {
        GameObject newGameObject = enemies[index];
        newGameObject.SetActive(false);
        pooledEnemies.Add(newGameObject);
        return (GameObject)Instantiate(newGameObject);
    }

    void DodGenerator()
    {
        float height = Random.Range(minHeight, maxHeight);
        float distanceBeetwen = Random.Range(minDistanceBeetween, maxDistanceBeetween);

        Invoke("DodGenerator", 1.0f);
        GameObject newEnemy = GetPolledEnemies(0);
        transform.position = new Vector3(transform.position.x + distanceBeetwen, height, 0);
        newEnemy.SetActive(true);
        Instantiate(newEnemy, transform.position, transform.rotation);
        

    }

    void BugGenerator()
    {
        float height = Random.Range(minHeight, maxHeight);
        float distanceBeetwen = Random.Range(minDistanceBeetween, maxDistanceBeetween);

        Invoke("BugGenerator", 2.0f);
        GameObject newEnemy = GetPolledEnemies(1);
        transform.position = new Vector3(transform.position.x + distanceBeetwen, height, 0);
        newEnemy.SetActive(true);
        Instantiate(newEnemy, transform.position, transform.rotation);
        

    }


    void Sprint()
    {
        //Invoke("Sprint", 1.0f);
        //GameObject newEnemy = GetPolledEnemies(2);
        //transform.position = new Vector3(0.45f, 6.155f, 0f);
        //newEnemy.SetActive(true);
        //sprintHolder = Instantiate(newEnemy, transform.position, transform.rotation);
        //Debug.Log(sprintHolder.GetComponent<Rigidbody2D>());

        float height = Random.Range(minHeight, maxHeight);
        float distanceBeetwen = Random.Range(minDistanceBeetween, maxDistanceBeetween);

        Invoke("Sprint", 3.0f);
        GameObject newEnemy = GetPolledEnemies(2);
        transform.position = new Vector3(transform.position.x + distanceBeetwen, height, 0);
        newEnemy.SetActive(true);
        Instantiate(newEnemy, transform.position, transform.rotation);
        

    }

    private IEnumerator Laser()
    {
        var tempColor = flash.color; 
        for(float i = 0; i < animationDuration; i += Time.deltaTime)
        {
            if (i == 0)
                stelarisShield.SetActive(true);
            if (i >= 2)
                laserBeamFromBoss.SetActive(true);
            if (i >= 4)
                euShield.SetActive(true);
            if (i >= 6)
                laserBeamToBoss.SetActive(true);
            if (i >= 6)
                tempColor.a = 0 + animationDuration;
            if (i >= 8)
                tempColor.a = 1 - animationDuration;

            if(i == 10)
            {
                FindObjectOfType<GameManager>().NextLevel();
                

            }



            yield return null;
        }
        yield return null;
        endAnimation = !endAnimation;
        laserBeam = null;
    }

}
