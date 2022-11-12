using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private float _afterCollisionTime;
    [SerializeField, Range(0.001f, 1f)] private float _dv = 0.01f;

    private Rigidbody2D _rigidbody;

    public static event UnityAction<Vector3> OnHeartInstantiate;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Timer()
    {
        float elapsed = 0;

        while (elapsed < _afterCollisionTime)
        {
            elapsed += Time.deltaTime;
            _rigidbody.gravityScale += _dv;

            if (_rigidbody.gravityScale > 1)
            {
                _rigidbody.gravityScale = 1;
            }

            yield return null;
        }

        gameObject.SetActive(false);
    }

    private void SetVelocity(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
        StartCoroutine(Timer());
    }

    public void ReactToCollision(Ball ball)
    {
        _rigidbody.AddForce(ball.Velocity * ball.Velocity * 10);
        SetVelocity(ball.Velocity);

        int heartProbability = Random.Range(0, 100);

        if (heartProbability > 90)
        { 
            OnHeartInstantiate?.Invoke(transform.position);
        }
    }

    public void ReactToCollision()
    {
        SetVelocity(Vector2.zero);
    }

    public void ReactToCollision(Rocket rocket)
    {
        gameObject.SetActive(false);
    }
}
