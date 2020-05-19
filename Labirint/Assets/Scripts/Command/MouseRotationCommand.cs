using System.Collections;
using UnityEngine;

public class MouseRotationCommand : Command
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
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(_rotate.RotationDirection);

        Vector2 direction = new Vector2(
            mousePostion.x - transform.position.x,
            mousePostion.y - transform.position.y
            );
        transform.up = direction;
    }
}