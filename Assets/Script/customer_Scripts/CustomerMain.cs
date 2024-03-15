using UnityEngine;

public class CustomerMain : MonoBehaviour
{
    public CustomerAnim CtmAnim;
    public CustomerOrder CtmOrder;
    public CustomerOrderUI CtmOrderUI;

    public void Start()
    {
        CtmOrder = GetComponent<CustomerOrder>();
        CtmOrderUI = GetComponent<CustomerOrderUI>();
        CtmAnim = GetComponent<CustomerAnim>();
    }
}
