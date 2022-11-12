using UnityEngine;

[RequireComponent(typeof(Rocket))]
[RequireComponent(typeof(RocketMover))]
[RequireComponent(typeof(BoxCollider2D))]
public class RocketCollision : MonoBehaviour
{
    private Rocket _rocket;
    private RocketMover _mover;

    private void Awake()
    {
        _rocket = GetComponent<Rocket>();
        _mover = GetComponent<RocketMover>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.ReactToCollision(_rocket);
            _mover.RestartMoving();
            _rocket.GetDamage();
        }
    }
}
