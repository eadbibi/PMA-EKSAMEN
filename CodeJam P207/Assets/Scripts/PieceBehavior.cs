using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PieceBehavior : MonoBehaviour
{

    private PlayerInput _playerInput;
    private InputAction _touchPositionAction;
    private InputAction _touchHoldPosition;
    private Vector2 _currentPosition;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPositionAction = _playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        _touchPositionAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        _touchPositionAction.performed -= TouchPressed;
    }


    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        Debug.Log(value);
        
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
