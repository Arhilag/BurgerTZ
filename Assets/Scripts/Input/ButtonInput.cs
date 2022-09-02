using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] private IngredientConfig _config;
    [SerializeField] private Button _button;
    public Action<IngredientConfig> OnClick;

    private void Awake()
    {
        _button.onClick.AddListener(Click);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        OnClick?.Invoke(_config);
    }
}
