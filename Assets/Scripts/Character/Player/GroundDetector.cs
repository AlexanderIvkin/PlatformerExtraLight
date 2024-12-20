using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_legs.position, _radius, _layerMask);

        if (colliders.Length > 0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
