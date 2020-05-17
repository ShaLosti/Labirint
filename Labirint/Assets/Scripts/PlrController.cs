using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed = 7f;
    private float _moveSpeed = 3f;

    private Rigidbody2D _rb;

    private PlrInput _plrInput = new PlrInput();
    void Start()
    {
        _moveSpeed = _walkSpeed;
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _plrInput.GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _plrInput.movementDirection * _moveSpeed * Time.fixedDeltaTime);
    }
}
