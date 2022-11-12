using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.ReactToCollision();
        }
    }
}
