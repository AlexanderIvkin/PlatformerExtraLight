using UnityEngine;

public class InputHandler : MonoBehaviour, IDirectable
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;

    public float GetHorizontalDirection() => Input.GetAxis(Horizontal);

    public bool IsJumpButtonPressed() => Input.GetKeyDown(JumpButton);
}
