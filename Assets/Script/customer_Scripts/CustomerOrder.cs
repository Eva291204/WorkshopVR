using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public CustomerMain CtmMain;
    public CustomerOrderUI orderUI;
    [field : SerializeField] public int orderTag { get; private set; }
    

    public void Start()
    {
        CtmMain = GetComponent<CustomerMain>();
    }

    public void SetupOrder()
    {
        int i = Random.Range(0, FoodManager.Instance.FoodList.Length);
        orderTag = FoodManager.Instance.FoodList[i].NumberTag;
    }

    // Afficher la commande
    public void AskOrder()
    {

    }

    public void CheckOrder()
    {

    }
}
