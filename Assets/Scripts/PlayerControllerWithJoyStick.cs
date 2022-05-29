using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWithJoyStick : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    
    private Vector3 direction;
    private Vector2 startTouchPosition, endTouchPosition;

    
    
 

    private void Update()
    {
        SwipeCheck();
    }

    public void FixedUpdate()
    {
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * (speed * Time.fixedDeltaTime), ForceMode.Impulse);
    }
    
    
    private void SwipeCheck()
    {
        if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch (1).position;

        if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Ended) 
        {
            endTouchPosition = Input.GetTouch (1).position;
            if (endTouchPosition.y > startTouchPosition.y)
            {
                if (endTouchPosition.y - startTouchPosition.y > 300)
                {
                    Debug.Log("Swipe");
                    Debug.Log(endTouchPosition.y - startTouchPosition.y);
                    rb.AddForce(new Vector3(0, 10, 0f), ForceMode.VelocityChange);
                }
            }
            
            if (endTouchPosition.x > startTouchPosition.x)
            {
                if (endTouchPosition.x - startTouchPosition.x > 300)
                {
                    Debug.Log("Swipe");
                    Debug.Log(endTouchPosition.x - startTouchPosition.x);
                    rb.AddForce(direction * (1000 * Time.fixedDeltaTime), ForceMode.Impulse);
                }
            }
        }
    }
    
  
}