using System;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public CustomerMain CtmMain;
    public CustomerOrderUI OrderUI;

    [field: SerializeField] public float OrderTimer { get; private set; }
    [field : SerializeField] public int OrderTag { get; private set; }
    private bool _orderAsked = false;

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
        if(OrderTag == i) {
            ScoreManager.Instance.SetScore(2);
            CtmMain.CtmAnim.LeaveFoodOutlet();
        }
        else {
            OrderTimedOut();
        }
    }


    public void OrderTimedOut() {
        _orderAsked = false;
        OrderUI.DesactiveOrderCard();

        ScoreManager.Instance.SetScore(-1);
        CtmMain.CtmAnim.LeaveFoodOutlet();
    }

    public void Update() {
        if (_orderAsked) {
            SetOrderTimerEvent(OrderTimer);
        }
    }
}
