using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 10;

    public GameObject player;

    public LayerMask wallLayer;

   RaycastHit hit;


    private void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("ChangeForceDirection", .1f, 3f);
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 10, wallLayer))
        {
            if (hit.rigidbody != null)
            {
                Debug.Log("Hitting");
                hit.rigidbody.AddForce(ray.direction * magnetForce);
            }
        }
        
        Debug.DrawRay(ray.origin, ray.direction * 10);
    }

    public void ChangeForceDirection()
    {
        magnetForce *= (-1);
    }

   
}
