using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetFinder : MonoBehaviour, IDirectable
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _viewDistance;

    public Transform Target { get; private set; }
    public bool IsFind { get; private set; }

    public float GetHorizontalDirection()
    {
        float dir = 0;

        if (Target != null)
        {
            dir = Target.position.x - transform.position.x;
        }

        return dir;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _viewDistance, _layerMask);

        if (hit)
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
