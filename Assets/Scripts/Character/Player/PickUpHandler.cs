using System;
using UnityEngine;

public class PickUpHandler: MonoBehaviour
{
    public event Action CoinPicked;
    public event Action<int> FirstAidKitPicked;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item item))
        {
            if (item is Coin)
            {
                CoinPicked?.Invoke();
            }
            else if (item is FirstAidKit)
            {
                FirstAidKit firstAidKit = item as FirstAidKit;
                FirstAidKitPicked?.Invoke(firstAidKit.BonusHeal);
            }
            else
            {
                Debug.Log("Выбрось каку! Или определи нормально, что подобрал! =))");
            }

            item.PickUp();
        }
    }
}