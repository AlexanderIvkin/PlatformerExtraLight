using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Item: MonoBehaviour
{
    public void PickUp()
    {
        float delay = 0.02f;

        Destroy(gameObject, delay);
    }
}
