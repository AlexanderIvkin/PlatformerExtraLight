using System;
using UnityEngine;

public class Counter: MonoBehaviour
{
    public event Action<int> CountChanged;

    [SerializeField] private int _count = 0;

    public string Name { get; protected set; }

    public void Increase()
    {
        _count++;
        CountChanged?.Invoke(_count);
    }
}
