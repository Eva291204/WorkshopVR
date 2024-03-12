using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject Customer;
    [SerializeField] private Transform SpawnPoint;

    public void CustomerSpawn()
    {
        Customer.transform.position = SpawnPoint.position;
    }
}
