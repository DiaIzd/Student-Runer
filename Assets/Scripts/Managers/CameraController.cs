using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Student thePlayer;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    private Vector3 offset;

    void Start()
    {
        thePlayer = FindObjectOfType<Student>();
        lastPlayerPosition = thePlayer.transform.position;
        offset = transform.position - thePlayer.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
    }

    void LateUpdate()
    {
        transform.position = thePlayer.transform.position + offset;
    }
}
