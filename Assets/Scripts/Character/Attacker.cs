using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private int _delay;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private LayerMask _layerMask;

    private float _damageDealRadius = 1f;

    public event Action Attacked;

    public bool IsRecharge { get; private set; } = true;

    public void Execute()
    {
        if (IsRecharge)
        {
            Hit();
            Attacked?.Invoke();
            StartCoroutine(TurnRecharge());
        }
    }

    private IEnumerator TurnRecharge()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        IsRecharge = false;

        yield return wait;

        IsRecharge = true;
    }

    private void Hit()
    {
        Collider2D hit = Physics2D.OverlapCircle(_raycastPoint.position, _damageDealRadius, _layerMask);

        if (hit != null && hit.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(_damage);
        }
    }
}
