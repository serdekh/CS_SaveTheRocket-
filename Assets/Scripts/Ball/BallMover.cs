using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class BallMover : MonoBehaviour
{
    [SerializeField, Range(1, 30)] private float _speed;

    private Coroutine _coroutine;
    private Rigidbody2D _rigidbody;

    public float Speed => _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartMoving();
    }

    private void OnEnable()
    {
        Rocket.OnDeath += StopMoving;
    }

    private void OnDisable()
    {
        Rocket.OnDeath -= StopMoving;
    }

    private IEnumerator MoveBall()
    {
        while (true)
        {
            //for PC
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
            float y = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

            transform.position += new Vector3(x, y);

            //for Android
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                touchPosition.z = 0;     
                _rigidbody.position = touchPosition;

                if (touch.phase == TouchPhase.Ended)
                {
                    _rigidbody.velocity = Vector2.zero;
                }
            }

            yield return null;

        }      
    }

    private void StartMoving()
    {
        _coroutine = StartCoroutine(MoveBall());
    }

    private void StopMoving()
    {
        StopCoroutine(_coroutine);
        _rigidbody.velocity = Vector2.zero;
    }
}
