using TMPro;
using UnityEngine;

public class HealthShower : MonoBehaviour
{
    private const string Name = "Монеты: ";

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;

    private int _count;

    private void OnEnable()
    {
        _health.CountChanged += ChangeCount;
    }

    private void OnDisable()
    {
        _health.CountChanged -= ChangeCount;
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
