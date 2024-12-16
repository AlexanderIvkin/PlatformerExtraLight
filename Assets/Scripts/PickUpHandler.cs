using UnityEngine;

public class PickUpHandler: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IPickUpable>(out IPickUpable item))
        {
            item.PickUp();
        }
    }
}
