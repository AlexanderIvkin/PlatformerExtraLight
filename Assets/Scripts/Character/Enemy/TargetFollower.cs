using UnityEngine;

public class TargetFollower : MonoBehaviour, IDirectable
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _viewDistance;
    [SerializeField] private Transform _raycastPoint;

    public Transform Target { get; private set; }
    public bool IsFind { get; private set; }

    public float GetHorizontalDirection()
    {
        float direction = 0;

        if (Target != null)
        {
            direction = Target.position.x - transform.position.x;
        }

        return direction;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position, transform.right, _viewDistance, _layerMask);

        if (hit.collider != null)
        {
            Select(hit);
        }
        else
        {
            Deselect();
        }
    }

    private void Select(RaycastHit2D target)
    {
        IsFind = true;
        Target = target.transform;
    }

    private void Deselect()
    {
        IsFind = false;
        Target = null;
    }
}
