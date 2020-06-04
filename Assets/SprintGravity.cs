using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintGravity : MonoBehaviour
{
   
    public void changeGravity(float gravity)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
}
