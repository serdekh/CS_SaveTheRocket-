using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Rocket))]
[RequireComponent(typeof(Rigidbody2D))]
public class RocketMover : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed;

    private Rocket _rocket;
    private Coroutine _coroutine;
    private Rigidbody2D _rigidbody;

    private bool _isMoving;

    public bool IsMoving => _isMoving;
    public float VerticalSpeed => _verticalSpeed;
    public Vector2 VerticalVelocity => _rigidbody.velocity;

    public event UnityAction OnStartingMoving;
    public event UnityAction OnStoppingMoving;

    private void Awake()
    {
        _rocket = GetComponent<Rocket>();
        _rigidbody = GetComponent<Rigidbody2D>();
        StartMoving();
    }

    private IEnumerator Move()
    {
        var fixedTime = new WaitForFixedUpdate();      

        while (true)
        {
            _rocket.UpdateScore();
            yield return fixedTime;
        }
    }

    public void StartMoving()
    {
        if (_coroutine == null)
        {
            OnStartingMoving?.Invoke();
            _rigidbody.velocity = new Vector2(0, _verticalSpeed);
            _coroutine = StartCoroutine(Move());
            _isMoving = true;
        }                  
    }

    public void StopMoving()
    {
        if (_coroutine != null)
        {
            OnStoppingMoving?.Invoke();
            _rigidbody.velocity = Vector2.zero;
            StopCoroutine(_coroutine);
            _isMoving = false;
        }
    }

    public void RestartMoving()
    {
        _coroutine = null;
        _rigidbody.velocity = new Vector2(0, _verticalSpeed);
        _coroutine = StartCoroutine(Move());
        _isMoving = true;
    }
}
