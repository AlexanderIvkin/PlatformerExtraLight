using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Fliper _fliper;

    private Rigidbody2D _rigidbody2D;

    public event Action Moved;
    public event Action Stopped;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {


        if (Mathf.Abs(direction) > 0)
        {
            _fliper.Flip(direction);
            _rigidbody2D.velocity = new Vector2(direction * _speed, _rigidbody2D.velocity.y);
            Moved?.Invoke();
        }
        else
        {
            Stopped?.Invoke();
        }
    }
}
