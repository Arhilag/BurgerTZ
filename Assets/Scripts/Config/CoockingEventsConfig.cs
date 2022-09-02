using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CockingEvents", menuName = "ScriptableObjects/CockingEventsConfig", order = 3)]
public class CoockingEventsConfig : ScriptableObject
{
    public Action<List<IngredientConfig>> OnBurgerComplete;
    public Action<List<IngredientConfig>> OnSetOrder;
    public Action OnCorrectlyBurger;
    public Action OnIncorrectlyBurger;
    public Action<int> OnAccrualReward;
}
