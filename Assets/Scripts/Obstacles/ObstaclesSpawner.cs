using System.Collections;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private ObstaclesBlock[] _obstacleBlocks;

    [SerializeField, Range(2, 10)] private float _delay;
    [SerializeField, Range(1, 10)] private float _distanceFromRocket;

    private RocketMover _mover;
    private Coroutine _coroutine;

    private void Start()
    {
        _mover = _rocket.GetComponent<RocketMover>();

        StartSpawning();
    }

    private void OnEnable()
    {
        Rocket.OnDeath += StopSpawning;
    }

    private void OnDisable()
    {
        Rocket.OnDeath -= StopSpawning;
    }

    private IEnumerator SpawnBlocks()
    {
        var delay = new WaitForSeconds(_delay);

        while (_mover.IsMoving)
        {
            Spawn();
            yield return delay;
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _obstacleBlocks.Length);

        Vector3 position = new Vector3(0, _rocket.transform.position.y + _distanceFromRocket);

        Instantiate(_obstacleBlocks[randomIndex], position, Quaternion.identity);
    }

    private void StartSpawning()
    {
        _coroutine = StartCoroutine(SpawnBlocks());
    }

    private void StopSpawning()
    {
        StopCoroutine(_coroutine);
    }
}
