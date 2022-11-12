using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Rocket : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _health = 1000;

    private int _score;
    private int _maxHealth;


    public int Score => _score;
    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public static event UnityAction OnDeath;
    public static event UnityAction OnScoreUpdate;
    public static event UnityAction OnHealthChange;

    private void Awake()
    {
        _maxHealth = _health;
    }

    private void OnEnable()
    {
        BallCollision.OnHeartCollision += Heal;
    }

    private void OnDisable()
    {
        BallCollision.OnHeartCollision -= Heal;
    }

    private void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }

    private void Heal()
    {
        _health++;

        if (_health > _maxHealth)
        {
            _maxHealth = _health;
        }

        OnHealthChange?.Invoke();
    }

    public void GetDamage()
    {
        _health--;

        OnHealthChange?.Invoke();

        if (_health <= 0)
        {
            Die();
        }
    }

    public void UpdateScore()
    {
        _score = (int)transform.position.y;
        OnScoreUpdate?.Invoke();
    }
}
