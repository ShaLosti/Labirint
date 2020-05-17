using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour, IMoveInput
{
    public Command movementInput;

    private PlrInputActions _inputActions;

    public Vector2 MoveDirection { get; private set; }

    private void Awake()
    {
        _inputActions = new PlrInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        if(movementInput)
            _inputActions.Plr.Movement.performed += OnMoveInput;
    }

    private void OnDisable()
    {
        _inputActions.Plr.Movement.performed -= OnMoveInput;
        _inputActions.Disable();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        MoveDirection = value;

        if (movementInput != null)
            movementInput.Execute();
    }
}
