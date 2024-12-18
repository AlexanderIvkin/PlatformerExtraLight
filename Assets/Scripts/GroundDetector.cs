using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _offsetX;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(_offsetX, _offsetY, 0), _radius);
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(_offsetX, _offsetY, 0), _radius, _layerMask);

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
