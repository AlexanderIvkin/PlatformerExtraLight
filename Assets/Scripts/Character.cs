using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private readonly int WalkAnimationParameter = Animator.StringToHash("Speed");

    protected IDirectable Directable;
    protected AnimationShower AnimationShower;

    private Animator _animator;
    private Mover _mover;
    private Fliper _fliper;

    protected virtual void Awake()
    {
        _fliper = GetComponent<Fliper>();
        _mover = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
        AnimationShower = new AnimationShower(_animator);
    }

    protected virtual void FixedUpdate()
    {
        float direction = Directable.GetHorizontalDirection();

        _mover.Move(direction);
        _fliper.Flip(direction);
        AnimationShower.Show(WalkAnimationParameter, Mathf.Abs(direction));
    }
}
