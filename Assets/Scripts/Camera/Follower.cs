using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;

    private void Awake()
    {
        _offset =  transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        transform.position =  _target.position + _offset;
    }
}
