using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PickUpHandler))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(Jumper))]
public class Player : Character
{
    private readonly int JumpAnimationTrigger = Animator.StringToHash("Jump");

    private GroundDetector _groundDetector;
    private InputHandler _inputHandler;
    private Jumper _jumper;

    protected override void Awake()
    {
        base.Awake();

        _inputHandler = GetComponent<InputHandler>();
        Directable = _inputHandler;
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Jump(_inputHandler.IsJumpButtonPressed() && _groundDetector.IsGrounded);
    }

    private void Jump(bool isJumping)
    {
        if (isJumping)
        {
            AnimationShower.Show(JumpAnimationTrigger);
            _jumper.Jump();
        }
    } 
}
