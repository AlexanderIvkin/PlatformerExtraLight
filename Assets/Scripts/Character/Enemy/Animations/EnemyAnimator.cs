using UnityEngine;

public class EnemyAnimator 
{
    private readonly int WalkAnimationBool = Animator.StringToHash("Walk");
    private readonly int IdleAnimationBool = Animator.StringToHash("Idle");

    private Animator _animator;

    public EnemyAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void PlayWalk()
    {
        _animator.SetBool(WalkAnimationBool, Activate());
        _animator.SetBool(IdleAnimationBool, Deactivate());
    }

    public void PlayIdle()
    {
        _animator.SetBool(IdleAnimationBool, Activate());
        _animator.SetBool(WalkAnimationBool, Deactivate());
    }

    private bool Activate()
    {
        return true;
    }

    private bool Deactivate()
    {
        return false;
    }
}
