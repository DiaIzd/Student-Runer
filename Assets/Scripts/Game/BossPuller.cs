using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPuller : MonoBehaviour
{
    public GameObject[] enemies;
    public int numOfEnemies;
    List<GameObject> pooledEnemies;
    int random;
    private void Start()
    {
        pooledEnemies = new List<GameObject>();
        random = Random.Range(0, 4);
    }

    public GameObject GetPolledEnemies()
    {
        GameObject newGameObject = getRandomEnemy();
        newGameObject.SetActive(false);
        pooledEnemies.Add(newGameObject);
        return (GameObject)Instantiate(newGameObject);
    }

    private GameObject getRandomEnemy()
    {
        return enemies[random % numOfEnemies];
    }

    private void Update()
    {
        random = Random.Range(0, 4);
        GetPolledEnemies();
    }

    void enemiesInvoke()
    {

    }
}
