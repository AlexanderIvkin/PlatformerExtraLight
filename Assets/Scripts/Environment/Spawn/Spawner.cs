using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Item[] _items;
    [SerializeField] private int _delay;
    [SerializeField] private Transform _leftBound;
    [SerializeField] private Transform _rightBound;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isEnable = true;
        var wait = new WaitForSeconds(_delay);

        while (isEnable)
        {
            Vector2 randomPosition = new Vector2(Random.Range(_leftBound.position.x, _rightBound.position.x), 
                transform.position.y);

            Instantiate(_items[Random.Range(0, _items.Length)],
                randomPosition, 
                Quaternion.identity);

            yield return wait;
        }
    }
}
