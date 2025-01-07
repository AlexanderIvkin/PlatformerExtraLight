using System;
using System.Collections;
using UnityEngine;

public class Recharger : MonoBehaviour
{
    [SerializeField] private string _rechargingAgillityName;

    private Coroutine _spendTimeCoroutine;

    public event Action<float> Recharging;

    public bool IsRecharge { get; private set; } = true;

    public void Recharge(float cooldown)
    {
        if (_spendTimeCoroutine != null)
            return;

        _spendTimeCoroutine = StartCoroutine(SpendTime(cooldown));
    }

    private IEnumerator SpendTime(float cooldown)
    {
        var delay = new WaitForSecondsRealtime(cooldown);
        Recharging?.Invoke(cooldown);
        IsRecharge = false;

        yield return delay;

        IsRecharge = true;
        _spendTimeCoroutine = null;
    }
}
