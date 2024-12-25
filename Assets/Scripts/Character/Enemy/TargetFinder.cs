using System.Collections;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private float _viewDistance;

    public Transform Target { get; private set; } = null;
    public bool IsFind { get; private set; } = false;

    private void Start()
    {
        StartCoroutine(Scan());
    }

    private IEnumerator Scan()
    {
        float delay = 0.2f;
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(_raycastPoint.position, 
                transform.right, 
                _viewDistance, 
                _layerMask);

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
