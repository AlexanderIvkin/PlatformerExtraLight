using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private Mover _mover;
    [SerializeField] private PatrolHandler _patrolHandler;
    [SerializeField] private TargetFinder _targetFinder;
    [SerializeField] private TargetFollower _targetFollower;
    [SerializeField] private Recharger _recharger;
    [SerializeField] private Animator _animator;

    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = new EnemyAnimator(_animator);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _mover.Moved += _enemyAnimator.PlayWalk;
        _mover.Stopped += _enemyAnimator.PlayIdle;
        Attacker.Attacked += _enemyAnimator.PlayAttack;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _mover.Moved -= _enemyAnimator.PlayWalk;
        _mover.Stopped -= _enemyAnimator.PlayIdle;
        Attacker.Attacked -= _enemyAnimator.PlayAttack;
    }

    private void FixedUpdate()
    {
        if (Health.IsAlive == false)
            return;

        if (_targetFinder.IsFind)
        {
            if (Mathf.Abs(_targetFinder.Target.position.x - transform.position.x) <= _attackDistance)
            {
                if (_recharger.IsRecharge)
                {
                    Attacker.Execute();
                }
            }
            else
            {
                _targetFollower.Move();
            }
        }
        else
        {
            _patrolHandler.Move();
        }
    }
}
