using System.Collections.Generic;
using UnityEngine;

public class BurgerController : MonoBehaviour
{
    [SerializeField] private IngredientView _view;
    [SerializeField] private BurgerModel _model;
    private List<ButtonInput> _buttons;

    private void Awake()
    {
        _buttons = _view.GetButtons();
        foreach (var button in _buttons)
        {
            button.OnClick += _model.SetIngredient;
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            button.OnClick -= _model.SetIngredient;
        }
    }
}
