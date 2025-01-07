using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VampirismViewer : MonoBehaviour
{
    [SerializeField] private Image _agillityExecutingImageUI;
    [SerializeField] private SpriteRenderer _sealingHealthZoneImage;
    [SerializeField] private Vampirism _vampirism;

    private Coroutine _decreaseSmoothlyCoroutine;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        _vampirism.Executing += Show;
        _vampirism.Stopped += Hide;
    }

    private void OnDisable()
    {
        _vampirism.Executing -= Show;
        _vampirism.Stopped -= Hide;
    }

    private void Show(float executingTime)
    {
        _sealingHealthZoneImage.enabled = true;

        if (_decreaseSmoothlyCoroutine != null)
            return;

        _decreaseSmoothlyCoroutine = StartCoroutine(DecreaseSmoothly(executingTime));
    }

    private void Hide()
    {
        _sealingHealthZoneImage.enabled = false;
    }

    private IEnumerator DecreaseSmoothly(float cooldown)
    {
        float currentTime = cooldown;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(currentTime / cooldown, 0.0f, 1.0f);
            _agillityExecutingImageUI.fillAmount = normalizedValue;

            yield return null;
        }

        _decreaseSmoothlyCoroutine = null;
    }
}
