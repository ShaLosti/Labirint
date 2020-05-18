using System.Collections;
using UnityEngine;
public class InputMoveCommand : Command
{
    public AnimationCurve speed;

    private Rigidbody2D _rigidbody;
    private IMoveInput _move;
    private Coroutine _moveCoroutine;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _move = GetComponent<IMoveInput>();
        _transform = transform;
    }

    public override void Execute()
    {
        if (_moveCoroutine == null)
            _moveCoroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_move.MoveDirection != Vector2.zero)
        {
            var time = (Time.fixedDeltaTime * speed.Evaluate(_move.MoveDirection.magnitude));

            _rigidbody.MovePosition(new Vector2(_transform.position.x, _transform.position.y) + _move.MoveDirection * time);

            yield return null;
        }

        _moveCoroutine = null;
    }
}
