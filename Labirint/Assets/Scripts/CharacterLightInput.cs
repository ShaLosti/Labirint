using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLightInput : MonoBehaviour, IRotationInput
{
    public Command mouseRotate;

    private PlrInputActions _inputActions;

    public Vector2 RotationDirection { get; set; }

    private void Awake()
    {
        _inputActions = new PlrInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        if (mouseRotate)
            _inputActions.Plr.MouseAim.performed += OnMouseAim;
    }

    private void OnDisable()
    {
        _inputActions.Plr.Movement.performed -= OnMouseAim;
        _inputActions.Disable();
    }

    private void OnMouseAim(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        RotationDirection = value;
        if (mouseRotate != null)
            mouseRotate.Execute();
    }
}
