using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(Jumper))]
public class Player : Character
{
    private CollisionDetector _collisionDetector;
    private InputHandler _inputHandler;
    private Jumper _jumper;
    private int _groundCount = 0;

    protected override void Awake()
    {
        base.Awake();

        _inputHandler = GetComponent<InputHandler>();
        Directable = _inputHandler;
        _jumper = GetComponent<Jumper>();
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    private void OnEnable()
    {
        _collisionDetector.CollisionStarted += HandleCollisionEnter;
        _collisionDetector.CollisionStopped += HandleCollisionExit;
    }

    private void OnDisable()
    {
        _collisionDetector.CollisionStarted -= HandleCollisionEnter;
        _collisionDetector.CollisionStopped -= HandleCollisionExit;
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        _jumper.Jump(IsJumping() && _groundCount > 0);
    }

    private void HandleCollisionEnter(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Ground>(out _))
        {
            _groundCount++;
        }
        else if (gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {

        }
        else if(gameObject.TryGetComponent<Coin>(out Coin coid))
        {

        }
    }

    private void HandleCollisionExit(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Ground>(out _))
        {
            _groundCount--;
        }
    }

    private bool IsJumping()
    {
        return _inputHandler.IsJumpButtonPressed();
    }
}
