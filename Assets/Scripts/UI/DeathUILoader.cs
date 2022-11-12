using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class DeathUILoader : MonoBehaviour
{
    [SerializeField] private GameObject[] _UIComponents;

    private void OnEnable()
    {
        Rocket.OnDeath += SetActive;
    }

    private void OnDisable()
    {
        Rocket.OnDeath -= SetActive;
    }

    private void SetState(bool state)
    {
        foreach (var component in _UIComponents)
        {
            component.SetActive(state);
        }
    }

    public void SetActive()
    {
        SetState(true);
    }

    public void SetNotActive()
    {
        SetState(false);
    }
}
