using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BurgerCheckerModel : MonoBehaviour
{
    [SerializeField] private CoockingEventsConfig _eventsCoocking;
    private List<IngredientConfig> _orderIngredients;
    
    public Action<int> OnAccrualReward;

    private void Awake()
    {
        _eventsCoocking.OnBurgerComplete += CheckBurger;
        _eventsCoocking.OnSetOrder += GetOrder;
    }

    private void OnDestroy()
    {
        _eventsCoocking.OnBurgerComplete -= CheckBurger;
        _eventsCoocking.OnSetOrder -= GetOrder;
    }

    private async void CheckBurger(List<IngredientConfig> burger)
    {
        await Task.Delay(500);
        if (Check(burger, _orderIngredients))
        {
            _eventsCoocking.OnCorrectlyBurger?.Invoke();
            var count = CalculateReward(_orderIngredients);
            OnAccrualReward?.Invoke(count);
        }
        else
            _eventsCoocking.OnIncorrectlyBurger?.Invoke();
        
    }
    
    private bool Check(List<IngredientConfig> burger, List<IngredientConfig> order)
    {
        for (int i = 0; i < order.Count; i++)
        {
            if (order[i] != burger[i])
                return false;
        }

        return true;
    }

    private int CalculateReward(List<IngredientConfig> burger)
    {
        int reward = 0;
        foreach (var ingredient in burger)
        {
            reward += ingredient.Reward;
        }

        return reward;
    }

    private void GetOrder(List<IngredientConfig> order)
    {
        _orderIngredients = order;
    }
}
