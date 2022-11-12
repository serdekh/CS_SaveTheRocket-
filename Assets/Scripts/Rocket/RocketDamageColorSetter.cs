using UnityEngine;

[RequireComponent(typeof(Rocket))]
public class RocketDamageColorSetter : MonoBehaviour
{
    [SerializeField] private Color _from = Color.white;
    [SerializeField] private Color _to = Color.red;

    private Rocket _rocket;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rocket = GetComponent<Rocket>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Rocket.OnHealthChange += LerpRocketColor;
    }

    private void OnDisable()
    {
        Rocket.OnHealthChange -= LerpRocketColor;
    }

    private float GetColorNormalized()
    {
        float health = _rocket.Health;
        float maxHealth = _rocket.MaxHealth;

        return health / maxHealth;
    }

    private void LerpRocketColor()
    {
        _spriteRenderer.color = Color.Lerp(_to, _from, GetColorNormalized());
    }
}
