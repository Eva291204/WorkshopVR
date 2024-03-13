using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderUI : MonoBehaviour
{
    public CustomerOrder CtmOrder;

    [SerializeField] private GameObject OrderCard;
    [SerializeField] private GameObject OrderSprite;

    [SerializeField] private Image _orderSprite;
    [SerializeField] private Image _timerColor;
    public Slider OrderTimerSlider;

    private float sliderValue;

    public void Start()
    {
        CtmOrder = GetComponent<CustomerOrder>();
        if (OrderSprite.GetComponent<Image>() != null)
        {
            _orderSprite = OrderSprite.GetComponent<Image>();
        }
        else {
            Debug.Log("null");
        }
        CtmOrder.orderTimerEvent += Notify;
        OrderCard.SetActive(false);
    }

    public void ActiveOrderCard()
    {
        OrderCard.SetActive(true);
    }

    public void DesactiveOrderCard()
    {
        OrderCard.SetActive(false);
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
