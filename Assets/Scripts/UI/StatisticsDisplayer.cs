using TMPro;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class StatisticsDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _highestScore;
    [SerializeField] private XML_RocketHighestScore _highestScoreData;

    public void ShowHighestScore()
    {
        _highestScore.text = $"Highest score: {_highestScoreData.GetHighestScore()}";
    }
}
