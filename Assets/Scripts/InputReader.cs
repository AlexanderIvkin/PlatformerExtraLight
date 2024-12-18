using UnityEngine;

public class InputReader : MonoBehaviour, IMovable, IJumpable
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;

    private float _horizontalDirection;
    private bool _isJump;

    private void Update()
    {
        _isJump = Input.GetKeyDown(JumpButton);
        _horizontalDirection = Input.GetAxis(Horizontal);
    }

    public float GetHorizontalDirection()
    {
        return _horizontalDirection;
    }

    public bool IsJump()
    {
        return _isJump;
    }
}
