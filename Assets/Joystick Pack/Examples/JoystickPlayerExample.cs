using System.Collections;
using System.Collections.Generic;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    
    [SerializeField] private SwipeListener swipeListener ;
    [SerializeField] private Transform playerTransform ;
    [SerializeField] private float playerSpeed ;

    private Vector3 direction;

    private void OnEnable () {
        swipeListener.OnSwipe.AddListener (OnSwipe) ;
    }
    public void FixedUpdate()
    {
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    
    
    
    
    private void OnSwipe (string swipe) {
        switch (swipe) {
            
            case "Right":
                Debug.Log("Right");
                
                rb.AddForce(direction * 100 * Time.fixedDeltaTime, ForceMode.Impulse);
                
                break ;
            case "Up":
                Debug.Log("Up");
                
                rb.AddForce(new Vector3(0, 5, 0f), ForceMode.VelocityChange);
                break ;
            
        } 
    }
    
    
    private void OnDisable () {
        swipeListener.OnSwipe.RemoveListener (OnSwipe) ;
    }
}