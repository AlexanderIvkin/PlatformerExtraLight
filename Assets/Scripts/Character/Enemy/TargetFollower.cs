using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private TargetFinder _targetFinder;

    public void Move()
    {
        _mover.Move(GetHorizontalDirection());
    }

    private float GetHorizontalDirection()
    {
        Vector2 direction = new Vector2();

        if (_targetFinder.IsFind)
        {
            direction = (_targetFinder.Target.position - transform.position).normalized;
        }

        return direction.x;
    }

    
}
