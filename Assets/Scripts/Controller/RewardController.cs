using UnityEngine;

public class RewardController : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private BurgerCheckerModel _burgerCheckerModel;

    private void Awake()
    {
        _burgerCheckerModel.OnAccrualReward += _scoreView.AddReward;
    }

    private void OnDestroy()
    {
        _burgerCheckerModel.OnAccrualReward -= _scoreView.AddReward;
    }
}
