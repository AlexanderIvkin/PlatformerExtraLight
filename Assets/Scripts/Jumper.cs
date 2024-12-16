using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _power;

    private Rigidbody2D _rigidbody2d;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2d.AddForce(Vector2.up * _power, ForceMode2D.Impulse);
    }
}
