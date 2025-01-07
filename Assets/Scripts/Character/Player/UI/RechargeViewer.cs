using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechargeViewer : MonoBehaviour
{
    [SerializeField] private Image _coverImage;
    [SerializeField] private Recharger _recharger;

    private Coroutine _decreaseSmoothlyCoroutine;

    private void Awake()
    {
        _coverImage.fillAmount = 0;
    }

    private void OnEnable()
    {
        _recharger.Recharging += Show;
    }

    private void OnDisable()
    {
        _recharger.Recharging -= Show;
    }

    private void Show(float cooldown)
    {
        if (_decreaseSmoothlyCoroutine != null)
            return;

        _decreaseSmoothlyCoroutine = StartCoroutine(DecreaseSmoothly(cooldown));
    }

    private IEnumerator DecreaseSmoothly(float cooldown)
    {
        float currentTime = cooldown;

        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(currentTime / cooldown, 0.0f, 1.0f);
            _coverImage.fillAmount = normalizedValue;

            yield return null;
        }

        _decreaseSmoothlyCoroutine = null;
    }
}
