using UnityEngine;

public class Coin : MonoBehaviour, IPickUpable
{
    public void PickUp()
    {
        float delay = 0.1f;

        Destroy(gameObject, delay);
    }
}
