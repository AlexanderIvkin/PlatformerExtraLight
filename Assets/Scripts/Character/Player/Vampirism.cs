using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _executionTime;
    [SerializeField]private float _damageDealRadius;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private Recharger _recharger;
    [SerializeField] private Health _health;

    private Coroutine _stealingHealthCoroutine;

    public event Action<float> Executing;
    public event Action Stopped;

    public void Execute()
    {
        if (_recharger.IsRecharge)
        {
            if (_stealingHealthCoroutine != null)
                return;

            _stealingHealthCoroutine = StartCoroutine(TryStealingHealth());
        }
    }

    private IEnumerator TryStealingHealth()
    {
        Executing?.Invoke(_executionTime);
        float currentTime = _executionTime;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            Collider2D collider = TryFindTarget();

            if(collider != null && collider.TryGetComponent(out IDamageable target))
            {
                float damagePerTime = _damage * Time.deltaTime;
                target.TakeDamage(damagePerTime);
                _health.Increase(damagePerTime);
            }

            yield return null; 
        }

        Stopped?.Invoke();
        _recharger.Recharge(_cooldown);
        _stealingHealthCoroutine = null;
    }

    private Collider2D TryFindTarget()
    {
        Collider2D nearestTarget = null;
        float minDistance = 0f;
        Collider2D[] targets = Physics2D.OverlapCircleAll(_attackPoint.position, _damageDealRadius, _targetLayerMask);

        if (targets.Length > 0)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                float currentDistance = (transform.position - targets[i].transform.position).magnitude;

                if (i == 0)
                {
                    minDistance = currentDistance;
                }

                if (currentDistance <= minDistance)
                {
                    minDistance = currentDistance;
                    nearestTarget = targets[i];
                }
            }
        }

        return nearestTarget;
    }
}
