using System;
using UnityEngine;
using UnityEngine.InputSystem;
using RootNamespace.Command;

public class CharacterInput : MonoBehaviour, IMoveInput
{
    public Command movementInput;

    private Animator _animator;

    private PlrInputActions _inputActions;

    private Camera _mainCamer;

    public Vector2 MoveDirection { get; private set; }
    private void Awake()
    {
        _inputActions = new PlrInputActions();
        TryGetComponent<Animator>(out _animator);
        _mainCamer = Camera.main;
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _inputActions.Plr.MouseAim.performed += OnMouseAim;

        if (movementInput)
            _inputActions.Plr.Movement.performed += OnMoveInput;
    }

    private void OnDisable()
    {
        _inputActions.Plr.Movement.performed -= OnMoveInput;
        _inputActions.Plr.MouseAim.performed -= OnMouseAim;
        _inputActions.Disable();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        MoveDirection = value;

        if (movementInput != null)
            movementInput.Execute();
    }

    private void OnMouseAim(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        Vector2 rotationDirection = value;
        rotationDirection = _mainCamer.ScreenToWorldPoint(rotationDirection) - transform.position;
        _animator.SetFloat("MouseDirectionX", rotationDirection.x);
        _animator.SetFloat("MouseDirectionY", rotationDirection.y);

    }
}
