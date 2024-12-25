using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public event Action<int> Changed;
    public event Action Died;

    public int CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void Increase(int value)
    {
        if (IsIncomingValuePositive(value))
        {
            CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _maxValue);
            Changed?.Invoke(CurrentValue);
        }
    }

    public void Decrease(int value)
    {
        if (IsIncomingValuePositive(value))
        {
            CurrentValue = Mathf.Clamp(CurrentValue - value, 0, _maxValue);
            Changed?.Invoke(CurrentValue);
        }
        
        if (CurrentValue == 0)
        {
            Died?.Invoke();
        }
    }

    private bool IsIncomingValuePositive(int value)
    {
        bool isPositive = true;

        if (value <= 0)
        {
            isPositive = false;
        }

        return isPositive;
    }
}
