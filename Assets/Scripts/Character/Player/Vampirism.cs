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
            IDamageable target = TryFindTarget();

            if(target != null)
            {
                Debug.Log("Есть цель");
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

    private IDamageable TryFindTarget()
    {
        Debug.Log("Ищу цель");
        IDamageable nearestTarget = null;
        float minDistance = 0f;
        Collider2D[] targets = new Collider2D[7];
        int targetsCount = Physics2D.OverlapCircleNonAlloc(_attackPoint.position, _damageDealRadius, targets, _targetLayerMask);

        if (targetsCount > 0)
        {
            Debug.Log("Целей больше нуля");
            for (int i = 0; i < targetsCount; i++)
            {
                float currentDistance = Mathf.Abs((transform.position - targets[i].transform.position).magnitude);

                if (i == 0)
                {
                    minDistance = currentDistance;
                    Debug.Log("Присваеваем расстояние первой цели");
                }

                if (currentDistance <= minDistance)
                {
                    Debug.Log("Проверяем ещё цель");
                    minDistance = currentDistance;
                    nearestTarget = targets[i] as IDamageable;
                }
            }
        }

        return nearestTarget;
    }
}
