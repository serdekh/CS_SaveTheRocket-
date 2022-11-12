using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float _yDelta;
    
    private Camera _main;
    private RocketMover _rocket;

    public float YDelta => _yDelta;

    private void Awake()
    {
        _rocket = FindObjectOfType<RocketMover>();
        _main = Camera.main;
    }

    private void Update()
    {
        if (_rocket.IsMoving)
        {
            Follow();
        }
    }

    private void Follow()
    {
        _main.transform.position = new Vector3(
            _main.transform.position.x, 
            _rocket.transform.position.y + _yDelta, 
            _main.transform.position.z);
    }
}
