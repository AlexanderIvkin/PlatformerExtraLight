using UnityEngine;

public class InputReader : MonoBehaviour, IDirectable, IJumpable
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;

    private float _horizontalDirection;
    private bool _isJump;

    private void Update()
    {
        if (Input.GetKeyDown(JumpButton))
        {
            _isJump = true;
        }

        _horizontalDirection = Input.GetAxis(Horizontal);
    }

    public float GetHorizontalDirection()
    {
        return _horizontalDirection;
    }

    public bool IsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}