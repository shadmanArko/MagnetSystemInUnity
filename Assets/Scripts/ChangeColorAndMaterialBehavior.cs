using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAndMaterialBehavior : MonoBehaviour
{
    public Material material;

    public bool northPole;
    // Start is called before the first frame update
    void Start()
    {
        northPole = true;
        material.color = Color.red;
        InvokeRepeating("ChangeMaterialColor", 0.1f, 5f);
    }

    // Update is called once per frame
    public void ChangeMaterialColor()
    {
        if (material.color == Color.blue)
        {
            material.color = Color.red;
            northPole = true;
        }
        else
        {
            material.color = Color.blue;
            northPole = false;
        }
    }
    
    
}
