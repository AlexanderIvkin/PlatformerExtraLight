using UnityEngine;

[RequireComponent(typeof(Fliper))]
[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody2D;
    private Fliper _fliper;

    private void Awake()
    {
        _fliper = GetComponent<Fliper>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _fliper.Flip(direction);
        _rigidbody2D.velocity = new Vector2(direction * _speed, transform.localPosition.y);
    }
}
