using UnityEngine;

public class PatrolHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private int _currentWayPointIndex;

    private void Awake()
    {
        _currentWayPointIndex = 0;
    }

    public float GetHorizontalDirection()
    {
        Vector2 direction;
        float acceptableDirection = 0.05f;

        if (Mathf.Abs(transform.position.x - _wayPoints[_currentWayPointIndex].position.x) <= acceptableDirection)
        {
            _currentWayPointIndex = ++_currentWayPointIndex % _wayPoints.Length;
        }

        direction = (_wayPoints[_currentWayPointIndex].position - transform.position).normalized;

        return direction.x;
    }
}
