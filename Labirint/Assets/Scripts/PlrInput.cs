using UnityEngine;

public class PlrInput
{
    public Vector2 movementDirection;

    public void GetInputs()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
