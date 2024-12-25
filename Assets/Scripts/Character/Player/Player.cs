using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PickUpHandler))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(WalletViewer))]
public class Player : Character
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Jumper _jumper;
    private Mover _mover;
    private Fliper _fliper;
    private PickUpHandler _pickUpHandler;
    private Wallet _wallet;
    private PlayerAnimator _playerAnimator;

    private bool IsJumpPossible => _inputReader.IsJump() && _groundDetector.IsGrounded;

    protected override void Awake()
    {
        base.Awake();

        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _fliper = GetComponent<Fliper>();
        _pickUpHandler = GetComponent<PickUpHandler>();
        _wallet = GetComponent<Wallet>();
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _pickUpHandler.CoinPicked += TakeCoin;
        _pickUpHandler.FirstAidKitPicked += TakeFirstAidKit;
        _mover.Moved += PlayWalkAnimation;
        _mover.Stopped += PlayIdleAnimation;
        _jumper.Jumped += PlayJumpAnimation;
        Attacker.Attacked += PlayAttackAnimation;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _pickUpHandler.CoinPicked -= TakeCoin;
        _pickUpHandler.FirstAidKitPicked -= TakeFirstAidKit;
        _mover.Moved -= PlayWalkAnimation;
        _mover.Stopped -= PlayIdleAnimation;
        _jumper.Jumped -= PlayJumpAnimation;
        Attacker.Attacked -= PlayAttackAnimation;
    }

    private void FixedUpdate()
    {
        Move(_inputReader.GetHorizontalDirection());

        if (IsJumpPossible && IsAlive)
        {
            Jump();
        }

        Attack();
    }

    private void Move(float direction)
    {
        _mover.Move(direction);
        _fliper.Flip(direction);
    }

    private void Jump()
    {
        _jumper.Jump();
    }

    private void Attack()
    {
        if (_inputReader.IsAttack())
        {
            Attacker.Execute();
        }
    }

    private void TakeCoin()
    {
        _wallet.Increase();
    }

    private void TakeFirstAidKit(int value)
    {
        Health.Increase(value);
    }

    private void PlayIdleAnimation()
    {
        _playerAnimator.PlayIdle();
    }

    private void PlayWalkAnimation()
    {
        _playerAnimator.PlayWalk();
    }

    private void PlayJumpAnimation()
    {
        _playerAnimator.PlayJump();
    }

    private void PlayAttackAnimation()
    {
        _playerAnimator.PlayAttack();
    }
}
