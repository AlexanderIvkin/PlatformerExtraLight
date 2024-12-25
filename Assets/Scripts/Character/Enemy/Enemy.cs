using UnityEngine;

[RequireComponent(typeof(PatrolHandler))]
[RequireComponent(typeof(TargetFollower))]
[RequireComponent(typeof(TargetFinder))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Fliper))]
public class Enemy : Character
{
    private PatrolHandler _patrolHandler;
    private TargetFollower _targetFollower;
    private TargetFinder _targetFinder;
    private EnemyAnimator _enemyAnimator;
    private Mover _mover;

    protected override void Awake()
    {
        base.Awake();

        _mover = GetComponent<Mover>();
        _patrolHandler = GetComponent<PatrolHandler>();
        _targetFollower = GetComponent<TargetFollower>();
        _targetFinder = GetComponent<TargetFinder>();
        _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
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
        if (IsAlive)
        {
            if (_targetFinder.IsFind)
            {
                if (Mathf.Abs(_targetFinder.Target.position.x - transform.position.x) <= Attacker.Distance)
                {
                    Attacker.Execute();
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
}
