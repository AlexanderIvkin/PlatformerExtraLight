using System.Collections;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private float _viewDistance;
    [SerializeField] private Mover _mover;

    public Transform Target { get; private set; }
    public bool IsFind { get; private set; }

    private void Start()
    {
        StartCoroutine(Scan());
    }

    public void Move()
    {
        _mover.Move(GetHorizontalDirection());
    }

    private float GetHorizontalDirection()
    {
        Vector2 direction = new Vector2();

        if (Target != null)
        {
            direction = (Target.position - transform.position).normalized;
        }

        return direction.x;
    }

    private IEnumerator Scan()
    {
        float delay = 0.2f;
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position, transform.right, _viewDistance, _layerMask);

            if (hit.collider != null)
            {
                Select(hit.transform);
            }
            else
            {
                Deselect();
            }

            yield return wait;
        }
    }

    private void Select(Transform target)
    {
        IsFind = true;
        Target = target;
    }

    private void Deselect()
    {
        IsFind = false;
        Target = null;
    }
}
