using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Item[] _items;
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
            Instantiate(_items[Random.Range(0, _items.Length)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);

            yield return wait;
        }
    }
}
