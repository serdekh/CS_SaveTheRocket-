using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BackgroundColorSetter : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float _delay;

    private Color _end;
    private Camera _main;

    private void Awake()
    {
        _main = Camera.main;
        _end = Color.black;

        StartCoroutine(DarkerBackground());
    }

    private IEnumerator DarkerBackground()
    {
        var delay = new WaitForSeconds(_delay);

        while (_main.backgroundColor != _end)
        {
            _main.backgroundColor = Color.Lerp(_main.backgroundColor, _end, Time.deltaTime);
            yield return delay;
        }
    }
}
