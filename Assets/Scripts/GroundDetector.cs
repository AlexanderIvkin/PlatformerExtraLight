using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _groundCount;

    public bool IsGrounded => _groundCount > 0;

    private void Awake()
    {
        _groundCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _groundCount++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _groundCount--;
        }
    }
}
