using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> Changed;

    [SerializeField] private int _maxValue;

    public int CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void Increase(int value)
    {
        if (IsPositive(value))
        {
            CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _maxValue);
            Changed?.Invoke(CurrentValue);
        }
    }

    public void Decrease(int value)
    {
        if (IsPositive(value))
        {
            CurrentValue = Mathf.Clamp(CurrentValue - value, 0, _maxValue);
            Changed?.Invoke(CurrentValue);
        }
    }

    private bool IsPositive(int value)
    {
        bool isPositive = true;

        if (value <= 0)
        {
            isPositive = false;

            throw new Exception("Пытаемся изменить Здоровье на неверное значение!!!");
        }

        return isPositive;
    }
}
