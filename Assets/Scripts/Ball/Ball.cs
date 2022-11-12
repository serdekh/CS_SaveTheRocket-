using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private RocketMover _rocketMover;

    public Vector2 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rocketMover = FindObjectOfType<RocketMover>();

        if (_rocketMover.IsMoving)
        {
            SetRocketVelocity();
        }
    }

    public void SetRocketVelocity()
    {
        _rigidbody.velocity = _rocketMover.VerticalVelocity;
    }
}
