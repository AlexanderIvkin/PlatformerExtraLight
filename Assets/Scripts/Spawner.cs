using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_coin, _spawnPoints[i].position, Quaternion.identity);

            yield return wait;
        }
    }
}
