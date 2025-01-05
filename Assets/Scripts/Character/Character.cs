using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Attacker))]
public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private ParticleSystem _deathParticleSystem;

    public Health Health { get; protected set; }
    public Attacker Attacker { get; protected set; }

    protected virtual void Awake()
    {
        Health = GetComponent<Health>();
        Attacker = GetComponent<Attacker>();
    }

    protected virtual void OnEnable()
    {
        Health.Died += Die;
    }

    protected virtual void OnDisable()
    {
        Health.Died -= Die;
    }

    public void TakeDamage(float damage)
    {
        Health.Decrease(damage);
    }

    private void Die()
    {
        _deathParticleSystem.Play();
        Destroy(gameObject, 0.2f);
    }
}
