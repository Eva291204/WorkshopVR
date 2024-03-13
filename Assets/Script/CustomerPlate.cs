using Unity.VisualScripting;
using UnityEngine;

public class CustomerPlate : MonoBehaviour
{
    private static CustomerPlate _plateInstance;
    public static CustomerPlate Instance {
        get {
            if (_plateInstance == null) {
                Debug.Log("CustomerPlate is null");
            }
            return _plateInstance;
        }
    }

    public void Awake() {
        if (_plateInstance != null) {
            Destroy(this.gameObject);
        }
        else {
            _plateInstance = this;
        }
    }


    [field: SerializeField] public CustomerMain CtmMain { get; set; }

    public void GetCustomer(CustomerMain customer)
    {
        CtmMain = customer;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            for(int i = 0; i < FoodManager.Instance.FoodList.Length; i++)
            {
                if(collision.gameObject.name == FoodManager.Instance.FoodList[i].Food.name)
                {
                    Destroy(collision.gameObject);
                    CtmMain.CtmOrder.CheckOrder(FoodManager.Instance.FoodList[i].NumberTag);
                }
            }
        }
    }
}
