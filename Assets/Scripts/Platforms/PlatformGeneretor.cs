using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneretor : MonoBehaviour
{
    public Transform generationPoint;

    public GameObject lastPlatform;
    public GameObject coin;
    public int numOfPlatforms;
    public bool isEndlessMode;
    private int platformCounter=0;

    public float minDistanceBeetween;
    public float maxDistanceBeetween;

    public ObjectPooler objectPooler;
    public float buffPropability;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            if (isEndlessMode)
            {
                generatePlatform();
            }else if (platformCounter < numOfPlatforms-1)
            {
                ++platformCounter;
                generatePlatform();
                if (platformCounter == numOfPlatforms-1) generateLastPlatform();
            }
            
        }
    }

    private void generatePlatform()
    {

        float distanceBeetwen = Random.Range(minDistanceBeetween, maxDistanceBeetween);
        GameObject newPlatform = objectPooler.GetPolledPlatform();
        float height = Random.Range(-0.15f, 0.25f);
        transform.position = new Vector3(transform.position.x + newPlatform.GetComponent<BoxCollider2D>().size.x + distanceBeetwen, height, 0);
        newPlatform.tag = "platform";
        newPlatform.SetActive(true);
        //generate Coins
        if(!isEndlessMode) generateCoins(transform.position, newPlatform.GetComponent<BoxCollider2D>().size.x);
        Instantiate(newPlatform, transform.position, transform.rotation);

        //buff
        if (Random.Range(0, 100) < buffPropability)
        {
            GameObject newBuff = objectPooler.GetPolledBuff();
            transform.position = new Vector3(transform.position.x, height + 0.2f, 0);
            newBuff.SetActive(true);
            Instantiate(newBuff, transform.position, transform.rotation);
        }
    }

    private void generateLastPlatform()
    {
        float distanceBeetwen = Random.Range(minDistanceBeetween+1, maxDistanceBeetween);
        float height = Random.Range(-0.15f, 0.25f);
        transform.position = new Vector3(transform.position.x + lastPlatform.GetComponent<BoxCollider2D>().size.x + distanceBeetwen, height, 0);
        lastPlatform.SetActive(true);
        lastPlatform.tag = "lastPlatform";
        Instantiate(lastPlatform, transform.position, transform.rotation);
    }

    private void generateCoins(Vector3 vectorPlatform, float platformSize)
    {
        float startPoint = vectorPlatform.x-platformSize/2;
        float endPoint = startPoint+platformSize;    
        while (startPoint< endPoint)
        {
            Vector3 newVector = new Vector3(startPoint, vectorPlatform.y+0.1f, vectorPlatform.z);
            coin.SetActive(true);
            Instantiate(coin, newVector, transform.rotation);
            startPoint+=0.1f;
        }
    }
}
