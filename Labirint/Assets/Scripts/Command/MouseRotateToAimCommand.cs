using UnityEngine;

namespace RootNamespace.Command
{
    public class MouseRotateToAimCommand : Command
    {
        private IRotationInput _rotate;
        private GameObject _objectToRotate;
        private Coroutine _coroutine;

        private void Awake()
        {
            _rotate = GetComponent<IRotationInput>();
            _objectToRotate = transform.gameObject;
        }


        public override void Execute()
        {
            Rotate();
        }

        private void Rotate()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(_rotate.RotationDirection);

            Vector2 newPos = transform.parent.GetComponent<CircleCollider2D>().ClosestPoint(mousePosition);

            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

            Vector2 direction = new Vector2(
                mousePosition.x - transform.parent.position.x,
                mousePosition.y - transform.parent.position.y
                );
            transform.up = direction;
        }
    }
}