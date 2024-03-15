using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnim : MonoBehaviour
{
    public Animator CustomerAnimator;

    public void Start()
    {
        CustomerAnimator = GetComponent<Animator>();
    }

    public void GoToFoodOutlet() {
        CustomerAnimator.SetTrigger("GoToOutlet");
    }

    public void LeaveFoodOutlet()
    {

    }
}
