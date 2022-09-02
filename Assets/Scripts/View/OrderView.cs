using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderView : MonoBehaviour
{
    [SerializeField] private List<Image> _orderIcons;

    public List<Image> GetIcons()
    {
        return _orderIcons;
    }
}
