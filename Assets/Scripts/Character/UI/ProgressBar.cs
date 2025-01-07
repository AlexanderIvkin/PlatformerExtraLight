using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _imageFiller;

    public void SetValue(float currentValue, float maxValue)
    {
        _imageFiller.fillAmount = currentValue/maxValue;
    }

    public float DisplayedValue => _imageFiller.fillAmount;
}
