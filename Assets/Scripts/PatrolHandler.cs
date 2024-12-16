using UnityEngine;

public class PatrolHandler : MonoBehaviour, IDirectable
{
    [SerializeField] private float _walkingArea;

    private float _startPositionX;
    bool _isRightWalking;

    private void Awake()
    {
        _isRightWalking = true;
        _startPositionX = transform.localPosition.x;
    }

    public float GetHorizontalDirection()
    {

        if (Mathf.Abs(_startPositionX - transform.localPosition.x) >= _walkingArea)
        {
            _isRightWalking = !_isRightWalking;
        }

        return _isRightWalking ? 1 : -1;
    }
}
