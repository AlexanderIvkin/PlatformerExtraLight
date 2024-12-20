using TMPro;
using UnityEngine;

[RequireComponent(typeof(PatrolHandler))]
[RequireComponent(typeof(TargetFinder))]
[RequireComponent(typeof(Animator))]
public class Enemy : Character
{
    private PatrolHandler _patrolHandler;
    private TargetFinder _targetFinder;
    private EnemyAnimator _enemyAnimator;

    protected override void Awake()
    {
        base.Awake();

        _patrolHandler = GetComponent<PatrolHandler>();
        _targetFinder = GetComponent<TargetFinder>();
        Directable = _patrolHandler;
        _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
    }

    private void Update()
    {
        if (_targetFinder.Target == null)
        {
            Directable = _patrolHandler;
        }
        else
        {
            Directable = _targetFinder;
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
