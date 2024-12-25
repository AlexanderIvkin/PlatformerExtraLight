using UnityEngine;

public class PlayerAnimator
{
    private readonly int WalkAnimationBool = Animator.StringToHash("Walk");
    private readonly int IdleAnimationBool = Animator.StringToHash("Idle");
    private readonly int JumpAnimationTrigger = Animator.StringToHash("Jump");
    private readonly int AttackAnimationTrigger = Animator.StringToHash("Attack");

    private Animator _animator;

    public PlayerAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void PlayWalk()
    {
        _animator.SetBool(WalkAnimationBool, true);
        _animator.SetBool(IdleAnimationBool, false);
    }

    public void PlayIdle()
    {
        _animator.SetBool(IdleAnimationBool, true);
        _animator.SetBool(WalkAnimationBool, false);
    }

    public void PlayJump()
    {
        _animator.SetTrigger(JumpAnimationTrigger);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(AttackAnimationTrigger);
    }
}
