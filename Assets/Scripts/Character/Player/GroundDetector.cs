using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _layerMask;

    private Collider2D[] _groundColliders = new Collider2D[7];

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        StartCoroutine(Scan());
    }

    private IEnumerator Scan()
    {
        bool isEnable = true;
        float delay = 0.05f;
        var wait = new WaitForSecondsRealtime(delay);

        while (isEnable)
        {
            int groundCount = Physics2D.OverlapCircleNonAlloc(_legs.position, 
                _radius, 
                _groundColliders, 
                _layerMask);

            IsGrounded = groundCount > 0;

            yield return wait;
        }
    }
}
