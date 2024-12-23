using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _deathParticleSystem;

    protected IDirectable Directable;
    protected bool IsAlive;

    private Mover _mover;
    private Fliper _fliper;

    public Health Health { get; protected set; }

    protected virtual void Awake()
    {
        _fliper = GetComponent<Fliper>();
        _mover = GetComponent<Mover>();
        Health = GetComponent<Health>();
        IsAlive = true;
    }

    protected virtual void OnEnable()
    {
        Health.Died += Die;
    }

    protected virtual void OnDisable()
    {
        Health.Died -= Die;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.TakeDamage(_damage);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (IsAlive)
        {
            Move(Directable.GetHorizontalDirection());
        }
    }

    protected virtual void Move(float direction)
    {
        _mover.Move(direction);
        _fliper.Flip(direction);
    }

    public void TakeDamage(int damage)
    {
        Health.Decrease(damage);
    }

    private void Die()
    {
        IsAlive = false;
        _deathParticleSystem.Play();
        Destroy(gameObject, 0.2f);
    }
}
