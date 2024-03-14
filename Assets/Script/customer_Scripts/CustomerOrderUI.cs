using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderUI : MonoBehaviour
{
    public CustomerOrder CtmOrder;

    [SerializeField] private GameObject _orderCard;
    [SerializeField] private GameObject _orderSpriteGO;

    [SerializeField] private Image _orderSprite;
    [SerializeField] private Image _timerColor;
    public Slider OrderTimerSlider;

    private float sliderValue;

    public void Start()
    {
        CtmOrder = GetComponent<CustomerOrder>();
        if (_orderSpriteGO.GetComponent<Image>() != null)
        {
            _orderSprite = _orderSpriteGO.GetComponent<Image>();
        }
        else {
            Debug.Log("null");
        }
        CtmOrder.OrderTimerEvent += Notify;
        _orderCard.SetActive(false);
    }

    public void ActiveOrderCard()
    {
        _orderCard.SetActive(true);
    }

    public void DesactiveOrderCard()
    {
        _orderCard.SetActive(false);
    }

    public void SetOrderSprite(Sprite sprite) { 
        _orderSprite.sprite = sprite;
    }

    public void SetOrderTimerSlider(float orderDuration)
    {
        OrderTimerSlider.value = 0;
        OrderTimerSlider.minValue = 0;
        OrderTimerSlider.maxValue = orderDuration;
    }

    public void Notify(float value)
    {
        OrderTimerSlider.value = OrderTimerSlider.maxValue - value;
        if(OrderTimerSlider.value > (OrderTimerSlider.maxValue * 70) / 100) {
            _timerColor.color = Color.red;
        }
        else if(OrderTimerSlider.value > (OrderTimerSlider.maxValue * 45) / 100)
        {
            _timerColor.color = Color.yellow;
        }
        else
        {
            _timerColor.color = Color.green;
        }
    }
}
