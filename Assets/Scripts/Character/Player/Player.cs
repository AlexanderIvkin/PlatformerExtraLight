using UnityEngine;

public class Player : Character
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;
    [SerializeField] private PickUpHandler _pickUpHandler;
    [SerializeField] private Wallet _wallet;

    private PlayerAnimator _playerAnimator;

    private bool IsJumpPossible => _inputReader.IsJump() && _groundDetector.IsGrounded;
    private bool IsAttack => _inputReader.IsAttack();
    private bool IsVampirism => _inputReader.IsVampirism();

    private void Awake()
    {
        _playerAnimator = new PlayerAnimator(_animator);
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
        if (Health.IsAlive == false)
            return;

        _mover.Move(_inputReader.GetHorizontalDirection());

        if (IsJumpPossible)
        {
            _jumper.Jump();
        }

        if (IsAttack)
        {
            Attacker.Execute();
        }

        if (IsVampirism)
        {
            _vampirism.Execute();
        }
    }
}
