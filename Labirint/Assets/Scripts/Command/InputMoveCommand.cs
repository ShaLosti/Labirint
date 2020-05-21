using System.Collections;
using UnityEngine;

namespace RootNamespace.Command
{
    public class InputMoveCommand : Command
    {
        public AnimationCurve speed;

        private Rigidbody2D _rigidbody;
        private IMoveInput _move;
        private Coroutine _moveCoroutine;
        private Transform _transform;

        private void Awake()
        {
            TryGetComponent<Rigidbody2D>(out _rigidbody);
            TryGetComponent<IMoveInput>(out _move);
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
}