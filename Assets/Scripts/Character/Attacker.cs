using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private LayerMask _layerMask;

    private bool _isPossible = true;

    public event Action Attacked;

    public float Distance { get; private set; } = 1f;

    public void Execute()
    {
        if (_isPossible)
        {
            Hit();
            Attacked?.Invoke();
            StartCoroutine(TurnRecharge());
        }
    }

    private IEnumerator TurnRecharge()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        _isPossible = false;

        yield return wait;

        _isPossible = true;

        yield break;
    }

    private void Hit()
    {
        Collider2D hit = Physics2D.OverlapCircle(_raycastPoint.position, Distance, _layerMask);

        if (hit == null )
        {
            Debug.Log("некому");
        }
        else if(hit.TryGetComponent(out IDamageable target))
        {
            Debug.Log(hit.gameObject.name);
            target.TakeDamage(_damage);
        }
    }
}
