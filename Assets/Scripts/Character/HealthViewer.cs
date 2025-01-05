using UnityEngine;

public abstract class HealthViewer : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected float MaxValue => _health.MaxValue;
    protected float CurrentValue => _health.CurrentValue;

    private void OnEnable()
    {
        _health.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeValue;
    }

    protected abstract void ChangeValue(float value);
}
