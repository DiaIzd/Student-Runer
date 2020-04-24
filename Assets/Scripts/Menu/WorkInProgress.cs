using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkInProgress : MonoBehaviour
{

    public string back;

    public void Back()
    {
        SceneManager.LoadScene(back);
    }
    
}
