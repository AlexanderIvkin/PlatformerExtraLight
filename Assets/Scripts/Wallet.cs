using System;
using UnityEngine;

public class Wallet : Counter
{
    private string _name = "Монеты";

    private void Awake()
    {
        Name = _name;
    }
}

