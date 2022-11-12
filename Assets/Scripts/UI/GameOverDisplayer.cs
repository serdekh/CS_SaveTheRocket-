using UnityEngine;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class GameOverDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverDisplay;
    [SerializeField] private XML_RocketHighestScore _highestScore;

    private Rocket _rocket;

    private void Awake()
    {
        _rocket = FindObjectOfType<Rocket>();
    }

    private void OnEnable()
    {
        Rocket.OnDeath += DisplayScore;
    }

    private void OnDisable()
    {
        Rocket.OnDeath -= DisplayScore;
    }

    public void DisplayScore()
    {
        if (_rocket.Score > _highestScore.GetHighestScore())
        {
            gameOverDisplay.gameObject.SetActive(true);
            gameOverDisplay.text = $"You got new score!\n{_rocket.Score}\n Previous: {_highestScore.GetHighestScore()}";
        }     
    }
}
