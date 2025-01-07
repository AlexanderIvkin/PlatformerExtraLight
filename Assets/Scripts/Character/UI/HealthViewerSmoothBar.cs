using System.Collections;
using UnityEngine;

public class HealthViewerSmoothBar : HealthViewer
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private float _smoothDecreaseStep = 25f;

    private Coroutine _decreaseSmoothlyCoroutine;

    protected override void ChangeValue(float value)
    {
        if (_decreaseSmoothlyCoroutine != null)
        {
            StopCoroutine(_decreaseSmoothlyCoroutine);
        }

        _decreaseSmoothlyCoroutine = StartCoroutine(DecreaseSmoothly(value));
    }

    private IEnumerator DecreaseSmoothly(float targetValue)
    {
        float displayedValue = MaxValue * _progressBar.DisplayedValue;

        while (displayedValue != targetValue)
        {
            displayedValue = Mathf.MoveTowards(displayedValue,
                targetValue,
                _smoothDecreaseStep * Time.deltaTime);

            _progressBar.SetValue(displayedValue, MaxValue);

            yield return null;
        } 
        
        _decreaseSmoothlyCoroutine = null;                 
    }
}
