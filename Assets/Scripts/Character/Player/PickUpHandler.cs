using System;
using UnityEngine;

public class PickUpHandler: MonoBehaviour
{
    public event Action CoinPicked;
    public event Action FirstAidKitPicked;

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
                FirstAidKitPicked?.Invoke();
            }
            else
            {
                Debug.Log("Выбрось каку! Или определи нормально, что подобрал! =))");
            }

            item.PickUp();
        }
    }
}
