using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private float _viewDistance;

    public Transform Target { get; private set; } = null;
    public bool IsFind => Target != null;

    private void Start()
    {
        StartCoroutine(Scan());
    }

    private IEnumerator Scan()
    {
        bool isEnable = true;
        float delay = 0.2f;
        var wait = new WaitForSeconds(delay);

        while (isEnable)
        {
            RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position, 
                _raycastPoint.transform.right, 
                _viewDistance, 
                _layerMask);

            if (hit.collider != null)
            {
                Target = hit.transform;
            }
            else
            {
                Target = null;
            }

            yield return wait;
        }
    }
}
