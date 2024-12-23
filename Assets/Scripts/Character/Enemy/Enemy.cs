using UnityEngine;

[RequireComponent(typeof(PatrolHandler))]
[RequireComponent(typeof(TargetFollower))]
[RequireComponent(typeof(Animator))]
public class Enemy : Character
{
    private PatrolHandler _patrolHandler;
    private TargetFollower _targetFollower;
    private EnemyAnimator _enemyAnimator;

    protected override void Awake()
    {
        base.Awake();

        _patrolHandler = GetComponent<PatrolHandler>();
        _targetFollower = GetComponent<TargetFollower>();
        Directable = _patrolHandler;
        _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
    }

    private void Update()
    {
        if (IsAlive)
        {
            if (_targetFollower.Target == null)
            {
                Directable = _patrolHandler;
            }
            else
            {
                Directable = _targetFollower;
            }
        }
    }

    protected override void Move(float direction)
    {
        base.Move(direction);

        if (Mathf.Abs(direction) > 0)
        {
            _enemyAnimator.PlayWalk();
        }
        else
        {
            _enemyAnimator.PlayIdle();
        }
    }
}
