using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _button;
    [SerializeField] private float _damage;

    private void OnEnable()
    {
        _button.onClick.AddListener(DoDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DoDamage);
    }

    private void DoDamage()
    {
        _health.Decrease(_damage);
    }
}
