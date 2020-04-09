using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int poolAmount;
    List<GameObject> pooledObjectsColection;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjectsColection = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject gameObject = pooledObject;
            gameObject.SetActive(false);
            pooledObjectsColection.Add(gameObject);
        }
    }

    public GameObject GetPolledObject()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            if (!pooledObjectsColection[i].activeInHierarchy) return (GameObject)Instantiate(pooledObjectsColection[i]);
        }
        GameObject newGameObject = pooledObject;
        newGameObject.SetActive(false);
        pooledObjectsColection.Add(newGameObject);
        return (GameObject)Instantiate(newGameObject);
    }
}

