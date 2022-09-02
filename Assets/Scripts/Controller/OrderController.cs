using UnityEngine;

public class OrderController : MonoBehaviour
{
    [SerializeField] private OrderView _view;
    [SerializeField] private OrderModel _model;

    private void Start()
    {
        _model.SetContainer(_view.GetIcons());
    }
}
