using System.Collections.Generic;
using UnityEngine;

public class IngredientView : MonoBehaviour
{
    [SerializeField] private List<ButtonInput> _buttons;

    public List<ButtonInput> GetButtons()
    {
        return _buttons;
    }
}
