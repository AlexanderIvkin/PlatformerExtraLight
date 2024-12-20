using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour
{
    protected IDirectable Directable;

    private Mover _mover;
    private Fliper _fliper;

    protected virtual void Awake()
    {
        _fliper = GetComponent<Fliper>();
        _mover = GetComponent<Mover>();
    }

    protected virtual void FixedUpdate()
    {
        Move(Directable.GetHorizontalDirection());
    }

    protected virtual void Move(float direction)
    {
        _mover.Move(direction);
        _fliper.Flip(direction);
    }
}
