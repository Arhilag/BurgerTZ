using System;
using System.Collections.Generic;
using UnityEngine;

public class BurgerModel : MonoBehaviour
{
    [SerializeField] private BurgerSettings _settings;
    [SerializeField] private CoockingEventsConfig _eventsCoocking;
    [SerializeField] [HideInInspector] private List<IngredientConfig> _order;
    [SerializeField] [HideInInspector] private List<GameObject> _burger;

    private float _ingredientNextHeight;
    private int _countIngredients;
    private void Awake()
    {
        _eventsCoocking.OnCorrectlyBurger += DeleteBurger;
        _eventsCoocking.OnIncorrectlyBurger += DeleteBurger;
    }

    private void OnDestroy()
    {
        _eventsCoocking.OnCorrectlyBurger -= DeleteBurger;
        _eventsCoocking.OnIncorrectlyBurger -= DeleteBurger;
    }

    private void Start()
    {
        _countIngredients = _settings.CountIngredients + 2;
    }

    public void SetIngredient(IngredientConfig ingredient)
    {
        if(_countIngredients <= _order.Count)
            return;

        var obj = Instantiate(ingredient.Prefab, transform);
        obj.transform.SetParent(transform);
        obj.transform.position += new Vector3(0,_ingredientNextHeight,0);
        _order.Add(ingredient);
        _burger.Add(obj);
        _ingredientNextHeight += ingredient.Indent;
        
        if (_countIngredients == _order.Count)
            _eventsCoocking.OnBurgerComplete?.Invoke(_order);
    }

    private void DeleteBurger()
    {
        _order.Clear();
        foreach (var ingredient in _burger)
        {
            ingredient.SetActive(false);
        }
        _burger.Clear();
        _ingredientNextHeight = 0;
    }
}
