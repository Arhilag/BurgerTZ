using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    public void AddReward(int reward)
    {
        _score += reward;
        _scoreText.text = _score + "";
    }
}
