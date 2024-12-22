using System.Collections;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour, IDamageable
{
    public Health Health { get; protected set; }

    [SerializeField] protected int Damage;
    protected IDirectable Directable;

    private Fliper _fliper;
    private Mover _mover;

    protected virtual void Awake()
    {
        _fliper = GetComponent<Fliper>();
        _mover = GetComponent<Mover>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.TakeDamage(Damage);
        }
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

    private void AttackWhileCollisionStay(IDamageable target)
    {
        target.TakeDamage((int)(Damage * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        Health.Decrease(damage);
    }
}
