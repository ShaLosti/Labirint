using System;
using UnityEngine;
using UnityEngine.InputSystem;
using RootNamespace.Command;
using UnityEditor;

public class CharacterInput : MonoBehaviour, IMoveInput
{
    public Vector2 MoveDirection { get; private set; }

    public Command movementInput;

    [SerializeField] MenuManager menuManager;

    private Animator _animator;
    private PlrInputActions _inputActions;
    private Camera _mainCamer;

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

        _inputActions.Plr.Menu.performed += OnEscape;

        if (movementInput)
            _inputActions.Plr.Movement.performed += OnMoveInput;
    }

    private void OnDisable()
    {
        _inputActions.Plr.Movement.performed -= OnMoveInput;
        _inputActions.Plr.Menu.performed -= OnEscape;
        _inputActions.Plr.MouseAim.performed -= OnMouseAim;
        _inputActions.Disable();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        MoveDirection = value;
        _animator.SetFloat("MoveX", MoveDirection.x);
        _animator.SetFloat("MoveY", MoveDirection.y);
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

    private void OnEscape(InputAction.CallbackContext context)
    {
        //menuManager.gameObject.SetActive(!menuManager.gameObject.activeSelf);
        menuManager.ShowPauseMenu(!menuManager.gameObject.activeSelf);
    }
}
