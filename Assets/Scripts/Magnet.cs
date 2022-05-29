using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 10;

    public float magnetDistance = 10;
    
    public bool blueMagnet;

    public GameObject player;

    public LayerMask wallLayer;

    private ChangeColorAndMaterialBehavior _changeColorAndMaterialBehavior;

    private int _changeDirection;

    RaycastHit hit;


    private void Start()
    {
        if (blueMagnet)
        {
            _changeDirection = -1;
        }
        else
        {
            _changeDirection = 1;
        }
        player = GameObject.Find("Player");
        _changeColorAndMaterialBehavior = player.GetComponent<ChangeColorAndMaterialBehavior>();
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, magnetDistance, wallLayer))
        {
            if (hit.rigidbody != null)
            {
                if (_changeColorAndMaterialBehavior.northPole)
                {
                    hit.rigidbody.AddForce(ray.direction * (magnetForce * 1 * _changeDirection));
                }
                else
                {
                    hit.rigidbody.AddForce(ray.direction * (magnetForce * -1 * _changeDirection));
                }
            }
        }
        
        Debug.DrawRay(ray.origin, ray.direction * magnetDistance);
    }

  
}
