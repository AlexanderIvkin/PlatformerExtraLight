using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PickUpHandler))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(WalletViewer))]
public class Player : Character
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Jumper _jumper;
    private PickUpHandler _pickUpHandler;
    private Wallet _wallet;
    private PlayerAnimator _playerAnimator;

    private bool IsJumpPossible => _inputReader.IsJump() && _groundDetector.IsGrounded;

    protected override void Awake()
    {
        base.Awake();

        _inputReader = GetComponent<InputReader>();
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
        _pickUpHandler = GetComponent<PickUpHandler>();
        Directable = _inputReader;
        _wallet = GetComponent<Wallet>();
        _playerAnimator = new PlayerAnimator(GetComponent<Animator>());

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

    protected override void Move(float direction)
    {
        base.Move(direction);

        if(Mathf.Abs(direction) > 0)
        {
            _playerAnimator.PlayWalk();
        }
        else
        {
            _playerAnimator.PlayIdle();
        }
    }

    private void Jump()
    {
        _jumper.Jump();
        _playerAnimator.PlayJump();
    }

    private void TakeCoin()
    {
        _wallet.Increase();
    }

    private void TakeFirstAidKit()
    {
    }
}
