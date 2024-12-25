using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Attacker))]
public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private ParticleSystem _deathParticleSystem;

    protected bool IsAlive;

    public Health Health { get; protected set; }
    public Attacker Attacker { get; protected set; }

    protected virtual void Awake()
    {
        Health = GetComponent<Health>();
        Attacker = GetComponent<Attacker>();
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
