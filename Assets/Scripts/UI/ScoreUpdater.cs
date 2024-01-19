using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private VariantsUIHandler _variantsUIHandler;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _score = 0;

    private void OnEnable()
    {
        _variantsUIHandler.OnAllCorrectAnswersSelected += AddScore;
    }

    private void OnDisable()
    {
        _variantsUIHandler.OnAllCorrectAnswersSelected -= AddScore;
    }

    private void AddScore()
    {
        _score += 5;
        _scoreText.text = _score.ToString();
    }
}