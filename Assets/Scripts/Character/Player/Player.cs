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
    private PickUpHandler _pickUpHandler;
    private Wallet _wallet;
    private PlayerAnimator _playerAnimator;

    private bool IsJumpPossible => _inputReader.IsJump() && _groundDetector.IsGrounded;
    private bool IsAttackPossible => _inputReader.IsAttack() && Attacker.IsRecharge;

    protected override void Awake()
    {
        base.Awake();

        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _pickUpHandler = GetComponent<PickUpHandler>();
        _wallet = GetComponent<Wallet>();
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _pickUpHandler.CoinPicked += _wallet.Increase;
        _pickUpHandler.FirstAidKitPicked += Health.Increase;
        _mover.Moved += _playerAnimator.PlayWalk;
        _mover.Stopped += _playerAnimator.PlayIdle;
        _jumper.Jumped += _playerAnimator.PlayJump;
        Attacker.Attacked += _playerAnimator.PlayAttack;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _pickUpHandler.CoinPicked -= _wallet.Increase;
        _pickUpHandler.FirstAidKitPicked -= Health.Increase;
        _mover.Moved -= _playerAnimator.PlayWalk;
        _mover.Stopped -= _playerAnimator.PlayIdle;
        _jumper.Jumped -= _playerAnimator.PlayJump;
        Attacker.Attacked -= _playerAnimator.PlayAttack;
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            _mover.Move(_inputReader.GetHorizontalDirection());

            if (IsJumpPossible)
            {
                _jumper.Jump();
            }

            if (IsAttackPossible)
            {
                Attacker.Execute();
            }
        }
    }
}
