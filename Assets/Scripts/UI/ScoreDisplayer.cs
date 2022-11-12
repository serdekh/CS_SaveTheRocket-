using UnityEngine;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private TMP_Text _scoreDisplay;

    private void OnEnable()
    {
        Rocket.OnScoreUpdate += DisplayScore;
    }

    private void OnDisable()
    {
        Rocket.OnScoreUpdate -= DisplayScore;
    }

    public void DisplayScore()
    {
        _scoreDisplay.text = $"Score: {_rocket.Score}";
    }
}
