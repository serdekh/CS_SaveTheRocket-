using UnityEngine;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private TMP_Text _healthDisplay;

    private void Awake()
    {
        DisplayHealth();
    }

    private void OnEnable()
    {
        Rocket.OnHealthChange += DisplayHealth;
    }

    private void OnDisable()
    {
        Rocket.OnHealthChange -= DisplayHealth;
    }

    public void DisplayHealth()
    {
        _healthDisplay.text = $"Health: {_rocket.Health}";
    }
}
