using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PatrolHandler))]
[RequireComponent(typeof(TargetFollower))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Fliper))]
public class Enemy : Character
{
    private PatrolHandler _patrolHandler;
    private TargetFollower _targetFollower;
    private EnemyAnimator _enemyAnimator;
    private Mover _mover;
    private Fliper _fliper;
    private Coroutine UsualBehaviourCoroutine;
    private Coroutine AlarmBehaviourCoroutine;

    protected override void Awake()
    {
        base.Awake();

        _mover = GetComponent<Mover>();
        _fliper = GetComponent<Fliper>();
        _patrolHandler = GetComponent<PatrolHandler>();
        _targetFollower = GetComponent<TargetFollower>();
        _enemyAnimator = new EnemyAnimator(GetComponent<Animator>());
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _mover.Moved += PlayWalkAnimation;
        _mover.Stopped += PlayIdleAnimation;
        Attacker.Attacked += PlayAttackAnimation;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _mover.Moved -= PlayWalkAnimation;
        _mover.Stopped -= PlayIdleAnimation;
        Attacker.Attacked -= PlayAttackAnimation;
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            if (_targetFollower.IsFind == true)
            {
                StartCoroutine(FollowTargetCoroutine(_targetFollower.IsFind));
            }
            else
            {
                StartCoroutine(MoveWayPointsCoroutine(_targetFollower.Target == null));
            }
        }
    }

    private IEnumerator FollowTargetCoroutine(bool hasTarget)
    {
        while (hasTarget)
        {
            Move(_targetFollower.GetHorizontalDirection());
            Attack();

            yield return null;
        }

        yield break;
    }

    private IEnumerator MoveWayPointsCoroutine(bool isSafely)
    {
        while (isSafely)
        {
            Move(_patrolHandler.GetHorizontalDirection());

            yield return null;
        }

        yield break;
    }

    private void Attack()
    {
        if (_targetFollower.GetDistanceToTarget() <= Attacker.Distance)
        {
            Attacker.Execute();
        }
    }

    private void Move(float direction)
    {
        _mover.Move(direction);
        _fliper.Flip(direction);
    }

    private void PlayIdleAnimation()
    {
        _enemyAnimator.PlayIdle();
    }

    private void PlayWalkAnimation()
    {
        _enemyAnimator.PlayWalk();
    }

    private void PlayAttackAnimation()
    {
        _enemyAnimator.PlayAttack();
    }
}
