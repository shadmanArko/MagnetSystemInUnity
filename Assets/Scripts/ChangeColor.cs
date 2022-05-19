using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeMaterialColor", 0.1f, 3f);
    }

    // Update is called once per frame
    public void ChangeMaterialColor()
    {
        if (material.color == Color.blue)
        {
            material.color = Color.red;
        }
        else
        {
            material.color = Color.blue;
        }
    }
    
    
}
