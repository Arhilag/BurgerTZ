using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientPool", menuName = "ScriptableObjects/IngredientPools", order = 0)]
public class IngredientPool : ScriptableObject
{
    public List<IngredientConfig> Ingredients;
}
