using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneretor : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBeetwen;
    public float platformWidth;

    public ObjectPooler objectPooler;


    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBeetwen, transform.position.y,0);
           // Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform=objectPooler.GetPolledObject();
            newPlatform.SetActive(true);
            Instantiate(newPlatform, transform.position, transform.rotation);
        }
    }
}
