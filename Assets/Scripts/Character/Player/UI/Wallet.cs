using System;
using UnityEngine;

public class Wallet: MonoBehaviour
{
    public event Action<int> Changed;

    public int Value { get; private set; }

    public void Increase()
    {
        Value++;
        Changed?.Invoke(Value);
    }
}

