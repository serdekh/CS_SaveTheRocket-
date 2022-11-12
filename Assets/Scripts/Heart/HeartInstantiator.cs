using UnityEngine;

public class HeartInstantiator : MonoBehaviour
{
    [SerializeField] private Heart _heart;

    private void OnEnable()
    {
        Obstacle.OnHeartInstantiate += Create;
    }

    private void OnDisable()
    {
        Obstacle.OnHeartInstantiate -= Create;
    }

    private void Create(Vector3 position)
    {
        Instantiate(_heart, position + new Vector3(Random.Range(-5, 5), Random.Range(1, 5)), Quaternion.identity);
    }
}
