using TMPro;
using UnityEngine;

public class Shower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = $"{_counter.Name}";
    }

    private void OnEnable()
    {
        _counter.CountChanged += ChangeCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ChangeCount;
    }

    private void ChangeCount(int count)
    {
        _text.text = $"{_counter.Name}  {count}";
    }
}
