using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<GameObject> CollisionStarted;
    public event Action<GameObject> CollisionStopped;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionStarted?.Invoke(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionStopped?.Invoke(collision.gameObject);
    }
}
