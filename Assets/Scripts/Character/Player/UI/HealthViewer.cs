using TMPro;
using UnityEngine;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;
    [SerializeField] private string _title;


    private void Start()
    {
        _text.text = $"{_title} : {_health.CurrentValue}";
    }

    private void OnEnable()
    {
        _health.Changed += ShowCurrent;
    }

    private void OnDisable()
    {
        _health.Changed -= ShowCurrent;
    }

    private void ShowCurrent(int value)
    {
        _text.text = $"{_title} : {value}";
    }
}
