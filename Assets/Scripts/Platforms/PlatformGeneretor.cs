using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneretor : MonoBehaviour
{
    public Transform generationPoint;

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
            float distanceBeetwen = Random.Range(minDistanceBeetween,maxDistanceBeetween);
            GameObject newPlatform=objectPooler.GetPolledPlatform();
            float height= Random.Range(-0.15f, 0.25f);
            transform.position = new Vector3(transform.position.x + newPlatform.GetComponent<BoxCollider2D>().size.x + distanceBeetwen, height, 0);
            newPlatform.tag = "platform";
            newPlatform.SetActive(true);
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
    }
}
