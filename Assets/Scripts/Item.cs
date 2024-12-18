using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Item: MonoBehaviour
{
    public void PickUp()
    {
        float delay = 0.05f;

        Destroy(gameObject, delay);
    }
}
