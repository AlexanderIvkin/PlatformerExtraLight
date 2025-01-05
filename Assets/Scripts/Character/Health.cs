using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    public event Action<float> ValueChanged;
    public event Action Died;

    public float CurrentValue { get; private set; }
    public float MaxValue => _maxValue;
    public bool IsAlive => CurrentValue > 0;

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void Increase(float value)
    {
        if (value <= 0)
            return;

        CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _maxValue);
        ValueChanged?.Invoke(CurrentValue);
    }

    public void Decrease(float value)
    {
        if (value <= 0)
            return;

        CurrentValue = Mathf.Clamp(CurrentValue - value, 0, _maxValue);
        ValueChanged?.Invoke(CurrentValue);

        if (CurrentValue == 0 )
        {
            Died?.Invoke();
        }
    }
}
