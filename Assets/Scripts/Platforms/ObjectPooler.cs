using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject[] buffs;
    public int numOfBuffs;
    List<GameObject> pooledPlatformsColection;
    List<GameObject> pooledBuffsColection;

    int random;
    // Start is called before the first frame update
    void Start()
    {
        pooledPlatformsColection = new List<GameObject>();
        pooledBuffsColection = new List<GameObject>();
        random = Random.Range(0, 4);
    }

    public GameObject GetPolledPlatform()
    {
        GameObject newGameObject = getRandomPlatform();
        newGameObject.SetActive(false);
        pooledPlatformsColection.Add(newGameObject);
        return (GameObject)Instantiate(newGameObject);
    }

    public GameObject GetPolledBuff()
    {
        GameObject newGameObject = getRandomBuff();
        newGameObject.SetActive(false);
        pooledBuffsColection.Add(newGameObject);
        return (GameObject)Instantiate(newGameObject);
    }

    private GameObject getRandomPlatform()
    {
        return platforms[random%3];
    }

    private GameObject getRandomBuff()
    {
        return buffs[random%numOfBuffs];
    }

    private void Update()
    {
        random = Random.Range(0,4);
    }
}

