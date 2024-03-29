using System;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public CustomerMain CtmMain;
    public CustomerOrderUI OrderUI;

    [field: SerializeField] public float OrderTimer { get; private set; }
    [field : SerializeField] public int OrderTag { get; private set; }
    private bool _orderAsked = false;
    private bool _orderDone = false;

    public event Action<float> OrderTimerEvent;

    public void SetOrderTimerEvent(float timer)
    {
        OrderTimer -= Time.deltaTime;
        OrderTimerEvent?.Invoke(timer);
        if(OrderTimer <= 0) {
            OrderTimedOut();
        }
    }

    public void Start() {
        CtmMain = GetComponent<CustomerMain>();
        OrderUI = GetComponent<CustomerOrderUI>();
    }

    public void AskOrder() {
        OrderTimer = OrderDifficulty();

        int i = UnityEngine.Random.Range(0, FoodManager.Instance.FoodList.Length);
        OrderTag = FoodManager.Instance.FoodList[i].NumberTag;

        OrderUI.ActiveOrderCard();
        OrderUI.SetOrderSprite(FoodManager.Instance.FoodList[i].FoodSprite);
        OrderUI.SetOrderTimerSlider(OrderTimer);

        CustomerPlate.Instance.GetCustomer(this.CtmMain);
        _orderAsked = true;
        _orderDone = false;
    }

    public float OrderDifficulty() {
        if (ScoreManager.Instance.Score <= 10) {
            return GameManager.Instance.easy;
        }
        else if (ScoreManager.Instance.Score > 10 && ScoreManager.Instance.Score <= 30) {
            return GameManager.Instance.normal;
        }
        else {
            return GameManager.Instance.hard;
        }
    }

    public void CheckOrder(int i) {
        if(OrderTag == i && !_orderDone) {
            ScoreManager.Instance.SetScore(2);
            SoundManager.Instance.PlayGoodFoodSound();
            CtmMain.CtmAnim.LeaveFoodOutlet();
            
            OrderUI.DesactiveOrderCard();
            _orderAsked = false;
        }
        else {
            OrderTimedOut();
        }
        _orderDone = true;
    }


    public void OrderTimedOut() {
        _orderAsked = false;
        OrderUI.DesactiveOrderCard();

        ScoreManager.Instance.SetScore(-1);
        SoundManager.Instance.PlayBadFoodSound();

        CtmMain.CtmAnim.LeaveFoodOutlet();
    }

    public void Update() {
        if (_orderAsked) {
            SetOrderTimerEvent(OrderTimer);
        }
    }
}
