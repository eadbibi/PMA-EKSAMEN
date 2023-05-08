using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{

   
    
    private PlayerInput _playerInput;

    [SerializeField] private GameObject player;

    private InputAction _touchPositionAction;
    private InputAction _touchPressAction;

    private Vector2 _currentVector2Position;
    

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPressAction = _playerInput.actions["TouchPress"];
        _touchPositionAction = _playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
        _touchPositionAction.performed += TouchPosition;
    }


    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;
        _touchPositionAction.performed -= TouchPosition;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);
        
    }
    
    private void TouchPosition(InputAction.CallbackContext context)
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
