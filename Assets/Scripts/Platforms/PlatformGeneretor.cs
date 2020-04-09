using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneretor : MonoBehaviour
{
    public Transform generationPoint;

    public float minDistanceBeetween;
    public float maxDistanceBeetween;

    public ObjectPooler objectPooler;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            float distanceBeetwen = Random.Range(minDistanceBeetween,maxDistanceBeetween);
            GameObject newPlatform=objectPooler.GetPolledObject();
            float height= Random.Range(-0.5f, 0.5f);
            transform.position = new Vector3(transform.position.x + newPlatform.GetComponent<BoxCollider2D>().size.x + distanceBeetwen, height, 0);
            newPlatform.SetActive(true);
            Instantiate(newPlatform, transform.position, transform.rotation);
        }
    }
}
