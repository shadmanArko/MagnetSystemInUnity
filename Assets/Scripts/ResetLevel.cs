using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    void RestartLevel() //Restarts the level.
    {
        SceneManager. LoadScene(SceneManager. GetActiveScene(). name);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            RestartLevel();
        }
        
    }
}
