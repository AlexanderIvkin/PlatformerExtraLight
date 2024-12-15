using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private const string WalkAnimationParameter = "Speed";

    protected IDirectable Directable;

    private AnimationShower _animationShower;
    private Animator _animator;
    private Mover _mover;

    protected virtual void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
        _animationShower = new AnimationShower(_animator);
    }

    protected virtual void FixedUpdate()
    {
        float direction = Directable.GetHorizontalDirection();

        _mover.Move(direction);
        _animationShower.Show(WalkAnimationParameter, Mathf.Abs(direction));
    }
}
