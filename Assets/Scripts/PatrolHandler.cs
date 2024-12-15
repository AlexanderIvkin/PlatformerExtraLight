using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolHandler : MonoBehaviour, IDirectable
{
    [SerializeField] private float _walkingArea;

    private float _startPositionX;
    bool _isChangeDirection = true;


    private void Awake()
    {
        _startPositionX = transform.localPosition.x;
    }

    public float GetHorizontalDirection()
    {

        if(Mathf.Abs(_startPositionX - transform.localPosition.x) >= _walkingArea)
        {
            _isChangeDirection = !_isChangeDirection;
        }

        return _isChangeDirection? 1 : -1 ;
    }
}
