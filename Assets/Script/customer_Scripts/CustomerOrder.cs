using System;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public CustomerMain CtmMain;
    public CustomerOrderUI orderUI;

    [field: SerializeField] public float orderTimer { get; private set; }
    [field : SerializeField] public int orderTag { get; private set; }
    private bool _orderAsked = false;

    public event Action<float> orderTimerEvent;

    public void SetOrderTimerEvent(float timer)
    {
        orderTimer -= Time.deltaTime;
        orderTimerEvent?.Invoke(timer);
        if(orderTimer <= 0) {
            OrderTimedOut();
        }
    }

    public void Start() {
        CtmMain = GetComponent<CustomerMain>();
        orderUI = GetComponent<CustomerOrderUI>();
        AskOrder();
    }

    public void AskOrder() {
        orderTimer = OrderDifficulty();

        int i = UnityEngine.Random.Range(0, FoodManager.Instance.FoodList.Length);
        orderTag = FoodManager.Instance.FoodList[i].NumberTag;

        orderUI.ActiveOrderCard();
        orderUI.SetOrderSprite(FoodManager.Instance.FoodList[i].FoodSprite);
        orderUI.SetOrderTimerSlider(orderTimer);

        CustomerPlate.Instance.GetCustomer(this.CtmMain);
        _orderAsked = true;
    }

    public float OrderDifficulty() {
        if (ScoreManager.Instance.Score <= 10) {
            return 30f;
        }
        else if (ScoreManager.Instance.Score > 10 && ScoreManager.Instance.Score <= 30) {
            return 20f;
        }
        else {
            return 15f;
        }
    }

    public void CheckOrder(int i) {
        if(orderTag == i) {
            ScoreManager.Instance.SetScore(2);
            CtmMain.CtmAnim.LeaveFoodOutlet();
        }
        else {
            OrderTimedOut();
        }
    }


    public void OrderTimedOut() {
        _orderAsked = false;
        orderUI.DesactiveOrderCard();

        ScoreManager.Instance.SetScore(-1);
        CtmMain.CtmAnim.LeaveFoodOutlet();
    }

    public void Update() {
        if (_orderAsked) {
            SetOrderTimerEvent(orderTimer);
        }
    }
}
