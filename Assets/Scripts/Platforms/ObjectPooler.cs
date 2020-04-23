using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] platforms;
    public int poolAmount;
    List<GameObject> pooledObjectsColection;

    int random;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjectsColection = new List<GameObject>();
        random = Random.Range(0, 3);
    }

    public GameObject GetPolledObject()
    {
        GameObject newGameObject = getRandomPlatform();
        newGameObject.SetActive(false);
        pooledObjectsColection.Add(newGameObject);
        return (GameObject)Instantiate(newGameObject);
    }

    private GameObject getRandomPlatform()
    {
        return platforms[random];
    }

    private void Update()
    {
        random = Random.Range(0,3);
    }
}

