using UnityEngine;

[CreateAssetMenu(fileName = "IngredientConfig", menuName = "ScriptableObjects/IngredientConfigs", order = 2)]
public class IngredientConfig : ScriptableObject
{
    public GameObject Prefab;
    public Sprite Icon;
    public float Indent;
    public int Reward;
}
