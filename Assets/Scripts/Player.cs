using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PickUpHandler))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
public class Player : Character
{
    private readonly int JumpAnimationTrigger = Animator.StringToHash("Jump");

    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Jumper _jumper;
    private PickUpHandler _pickUpHandler;
    private Wallet _wallet;
    private Health _health;

    private bool IsJumpPossible => _inputReader.IsJump() && _groundDetector.IsGrounded;

    protected override void Awake()
    {
        base.Awake();

        _inputReader = GetComponent<InputReader>();
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
        _pickUpHandler = GetComponent<PickUpHandler>();
        Movable = _inputReader;
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();
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
        }
    }

    private void Jump()
    {
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
