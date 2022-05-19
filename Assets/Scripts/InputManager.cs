using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    private PlayerControls _playerControls;


    //public delegate void OnActionEvent();

    //public OnActionEvent OnTapInteractPerformed;
    //public OnActionEvent OnInventoryPress;
    //public OnActionEvent OnPausePress;
    

    private void Awake()
    {
        //Bad Code TODO Remove Singleton
        _playerControls = new PlayerControls();
        if (_instance != null && _instance != true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerControls.Player.Move.ReadValue<Vector2>();
    }
    
}
