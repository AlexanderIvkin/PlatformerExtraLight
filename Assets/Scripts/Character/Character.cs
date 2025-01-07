using UnityEngine;

[SelectionBase]
public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private ParticleSystem _deathParticleSystem;
    [SerializeField] protected Health Health;
    [SerializeField] protected Attacker Attacker;

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
