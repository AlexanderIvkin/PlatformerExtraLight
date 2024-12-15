using System.Collections;
using System.Collections.Generic;
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

    public void Jump(bool isJumping)
    {
        if (isJumping)
        {
            _rigidbody2d.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }
}
