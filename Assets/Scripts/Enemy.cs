using UnityEngine;

[RequireComponent(typeof(PatrolHandler))]
public class Enemy : Character
{
    protected override void Awake()
    {
        base.Awake();

        Directable = GetComponent<PatrolHandler>();
    }
}
