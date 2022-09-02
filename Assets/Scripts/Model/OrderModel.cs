using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class OrderModel : MonoBehaviour
{
    [SerializeField] private IngredientPool _ingredientPool;
    [SerializeField] private IngredientConfig _breadUp;
    [SerializeField] private IngredientConfig _breadDown;
    [SerializeField] [HideInInspector] private List<IngredientConfig> _order;
    [SerializeField] private CoockingEventsConfig _eventsCoocking;
    
    private List<Image> _orderContainer;

    private void Awake()
    {
        _eventsCoocking.OnCorrectlyBurger += ResetOrder;
    }

    private void OnDestroy()
    {
        _eventsCoocking.OnCorrectlyBurger -= ResetOrder;
    }

    private void Start()
    {
        GenerateOrder();
    }

    public void GenerateOrder()
    {
        _order.Add(_breadDown);
        for (int i = 0; i < _orderContainer.Count; i++)
        {
            var random = Random.Range(0, _ingredientPool.Ingredients.Count);
            var config = _ingredientPool.Ingredients[random];
            _orderContainer[i].sprite = config.Icon;
            _order.Add(config);
        }
        _order.Add(_breadUp);
        _eventsCoocking.OnSetOrder?.Invoke(_order);
    }

    public void SetContainer(List<Image> orderIcons)
    {
        _orderContainer = orderIcons;
    }

    private void ResetOrder()
    {
        _order.Clear();
        GenerateOrder();
    }
}
