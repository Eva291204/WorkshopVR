using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnim : MonoBehaviour
{
    public Animator CustomerAnimator;
    public CustomerMain CtmMain;

    public void Start()
    {
        CtmMain = GetComponent<CustomerMain>();
    }

    public void GoToFoodOutlet() { 
        
    }

    public void LeaveFoodOutlet()
    {

    }
}
