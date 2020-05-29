using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPuller : MonoBehaviour
{
    public GameObject[] enemies;
    List<GameObject> pooledEnemies;
    public int index;
    public GameManager gameManager;

    public float EnemiesPropability;
    public float minDistanceBeetween = 2;
    public float maxDistanceBeetween = 2;
    public float maxHeight;
    public float minHeight;
    public float winTime;



    private void Start()
    {
        pooledEnemies = new List<GameObject>();
        Invoke("DodGenerator", 1.0f);
        Invoke("BugGenerator", 1.5f);

    }

    private void FixedUpdate()
    {
        winTime += Time.deltaTime;
        if(winTime >= 10.0f && gameManager.gameHasEnded == false)
        {
            FindObjectOfType<GameManager>().NextLevel();
        }
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

        Invoke("BugGenerator", 1.0f);
        GameObject newEnemy = GetPolledEnemies(1);
        transform.position = new Vector3(transform.position.x + distanceBeetwen, height, 0);
        newEnemy.SetActive(true);
        Instantiate(newEnemy, transform.position, transform.rotation);

    }




}
