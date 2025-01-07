using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private Recharger _recharger;

    private float _damageDealRadius = 1f;

    public event Action Attacked;

    public void Execute()
    {
        if (_recharger.IsRecharge)
        {
            Hit();
            Attacked?.Invoke();
            _recharger.Recharge(_cooldown);
        }
    }

    private void Hit()
    {
        Collider2D hit = Physics2D.OverlapCircle(_attackPoint.position, _damageDealRadius, _targetLayerMask);

        if (hit != null && hit.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(_damage);
        }
    }
}
