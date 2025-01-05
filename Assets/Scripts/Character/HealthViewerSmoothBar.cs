using System.Collections;
using UnityEngine;

public class HealthViewerSmoothBar : HealthViewer
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private float _smoothDecreaseStep = 25f;

    private Coroutine _decreaseSmoothly;

    protected override void ChangeValue(float value)
    {
        if (_decreaseSmoothly != null)
        {
            StopCoroutine(_decreaseSmoothly);
        }

        _decreaseSmoothly = StartCoroutine(DecreaseSmoothly(value));

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
        
        _decreaseSmoothly = null;                 
    }
}
