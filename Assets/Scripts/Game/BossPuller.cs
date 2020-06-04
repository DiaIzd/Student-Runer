using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private static GameObject sprintHolder;
    public SprintGravity sprintGravity;
    public Student thePlayer;

    [SerializeField, Range(0.1f, 40)]
    private float winTime = 1;

    [SerializeField]
    private float enemiesDestroyer = -300f;



    

    private void Start()
    {
        pooledEnemies = new List<GameObject>();
        Invoke("DodGenerator", 1.0f);
        Invoke("BugGenerator", 2.0f);
        Invoke("Sprint", 3.0f);
        //Sprint();

    }

    private void FixedUpdate()
    {
        
        winTime += Time.deltaTime;
        if(winTime >= 40.0f && gameManager.gameHasEnded == false)
        {
            FindObjectOfType<GameManager>().NextLevel();
            Time.timeScale = 0;
            thePlayer.gameObject.SetActive(false);
            
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



}
