using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public event Action Moved;
    public event Action Stopped;

    public void Move(float direction)
    {
        _fliper.Flip(direction);

        if (Mathf.Abs(direction) > 0)
        {
            _rigidbody2D.velocity = new Vector2(direction * _speed, _rigidbody2D.velocity.y);
            Moved?.Invoke();
        }
        else
        {
            Stopped?.Invoke();
        }
    }
}
