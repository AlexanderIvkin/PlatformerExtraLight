using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletShower : MonoBehaviour
{
    private const string Name = "Монеты: ";

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Wallet _wallet;

    private int _count;

    private void OnEnable()
    {
        _wallet.CountChanged += ChangeCount;
    }

    private void OnDisable()
    {
        _wallet.CountChanged -= ChangeCount;
    }

    private void LateUpdate()
    {
        _text.text = Name + _count;
    }

    private void ChangeCount(int count)
    {
        _count += count;
    }
}
