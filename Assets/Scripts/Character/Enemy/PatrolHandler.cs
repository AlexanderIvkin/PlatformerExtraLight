using UnityEngine;

public class PatrolHandler : MonoBehaviour, IDirectable
{
    [SerializeField] private Transform[] _wayPoints;

    private int _currentWayPoint;

    private void Awake()
    {
        _currentWayPoint = 0;
    }

    public float GetHorizontalDirection()
    {
        Vector2 direction;


        if (Mathf.Abs(transform.position.x - _wayPoints[_currentWayPoint].position.x) <= 0.05f)
        {
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;
        }

        direction = (_wayPoints[_currentWayPoint].position - transform.position).normalized;


        return direction.x;
    }
}
