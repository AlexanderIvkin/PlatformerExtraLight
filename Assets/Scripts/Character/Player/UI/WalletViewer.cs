using TMPro;
using UnityEngine;

public class WalletViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private string _title;

    private void Start()
    {
        _text.text = $"{_title} : {_wallet.Value}";
    }

    private void OnEnable()
    {
        _wallet.Changed += ShowCurrent;
    }

    private void OnDisable()
    {
        _wallet.Changed -= ShowCurrent;
    }

    private void ShowCurrent(int value)
    {
        _text.text = $"{_title} : {value}";
    }
}