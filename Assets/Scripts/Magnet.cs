using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 10;
    
    public bool redMagnet;

    public GameObject player;

    public LayerMask wallLayer;

    private ChangeColorAndMaterialBehavior _changeColorAndMaterialBehavior;

    private int _changeDirection;

    RaycastHit hit;


    private void Start()
    {
        if (redMagnet)
        {
            _changeDirection = -1;
        }
        else
        {
            _changeDirection = 1;
        }
        player = GameObject.Find("Player");
        _changeColorAndMaterialBehavior = player.GetComponent<ChangeColorAndMaterialBehavior>();
        // InvokeRepeating("ChangeForceDirection", .1f, 3f);
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 10, wallLayer))
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
        
        Debug.DrawRay(ray.origin, ray.direction * 10);
    }

    // public void ChangeForceDirection()
    // {
    //     magnetForce *= (-1);
    // }
}
