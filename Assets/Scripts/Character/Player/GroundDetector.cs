using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        Scan();
    }

    private void Scan()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_legs.position, _radius, _layerMask);

        IsGrounded = colliders.Length > 0;
    }
}
