using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ball))]
public class BallCollision : MonoBehaviour
{
    private Ball _ball;

    public static event UnityAction OnHeartCollision;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.ReactToCollision(_ball);
            _ball.SetRocketVelocity();
        }

        if (collision.transform.TryGetComponent(out Heart heart))
        {
            OnHeartCollision?.Invoke();
            heart.gameObject.SetActive(false);
        }
    }
}
