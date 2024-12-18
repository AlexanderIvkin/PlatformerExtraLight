using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PickUpHandler))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
public class Player : Character
{
    private readonly int JumpAnimationTrigger = Animator.StringToHash("Jump");

    private GroundDetector _groundDetector;
    private InputHandler _inputHandler;
    private Jumper _jumper;
    private PickUpHandler _pickUpHandler;
    private Wallet _wallet;
    private Health _health;
    private bool _isJumping;

    private bool IsJumpPossible => _inputHandler.IsJumpButtonPressed() && _groundDetector.IsGrounded() && !_isJumping;

    protected override void Awake()
    {
        base.Awake();

        _inputHandler = GetComponent<InputHandler>();
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
        _pickUpHandler = GetComponent<PickUpHandler>();
        Directable = _inputHandler;
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();
        _isJumping = false;
    }

    private void OnEnable()
    {
        _pickUpHandler.CoinPicked += TakeCoin;
        _pickUpHandler.FirstAidKitPicked += TakeFirstAidKit;
    }

    private void OnDisable()
    {
        _pickUpHandler.CoinPicked -= TakeCoin;
        _pickUpHandler.FirstAidKitPicked -= TakeFirstAidKit;

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (IsJumpPossible)
        {
            Jump();
            _isJumping = false;
        }
    }

    private void Jump()
    {
        _isJumping = true;
        AnimationShower.Show(JumpAnimationTrigger);
        _jumper.Jump();
    }

    private void TakeCoin()
    {
        _wallet.Increase();
    }

    private void TakeFirstAidKit()
    {
        _health.Increase();
    }
}
