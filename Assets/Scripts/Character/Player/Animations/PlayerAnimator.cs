using UnityEngine;

public class PlayerAnimator
{
    private readonly int WalkAnimationBool = Animator.StringToHash("Walk");
    private readonly int IdleAnimationBool = Animator.StringToHash("Idle");
    private readonly int JumpAnimationTrigger = Animator.StringToHash("Jump");

    private Animator _animator;

    public PlayerAnimator(Animator animator)
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

    public void PlayJump()
    {
        _animator.SetTrigger(JumpAnimationTrigger);
    }
}
