using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _offsetX;
    [SerializeField] private LayerMask _layerMask;

    //private int _groundCount;

    //public bool IsGrounded => _groundCount > 0;
    //public bool IsGroundedByRay { get; private set; }

    //private void Awake()
    //{
    //    _groundCount = 0;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Ground>(out _))
    //    {
    //        _groundCount++;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.gameObject.TryGetComponent<Ground>(out _))
    //    {
    //        _groundCount--;
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(_offsetX, _offsetY, 0), _radius);
    }

    public bool IsGrounded()
    {
        bool isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(_offsetX, _offsetY, 0), _radius, _layerMask);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.TryGetComponent<Ground>(out _))
            {
                isGrounded = true;
            }
        }

        return isGrounded;
    }
}
