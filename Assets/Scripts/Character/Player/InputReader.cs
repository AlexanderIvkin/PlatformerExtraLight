using UnityEngine;

public class InputReader : MonoBehaviour, IJumpable
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;
    private const KeyCode AttackButton = KeyCode.F;

    private float _horizontalDirection;
    private bool _isJump;
    private bool _isAttack;

    private void Update()
    {
        if (Input.GetKeyDown(JumpButton))
        {
            _isJump = true;
        }

        if (Input.GetKeyDown(AttackButton))
        {
            _isAttack = true;
        }

        _horizontalDirection = Input.GetAxis(Horizontal);
    }

    public float GetHorizontalDirection()
    {
        return _horizontalDirection;
    }

    public bool IsJump() => GetBoolAsTrigger(ref _isJump);

    public bool IsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}