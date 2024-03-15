using System.Collections.Generic;
using UnityEngine;

public class CustomerObjectPool : MonoBehaviour
{
    public CustomerMain CustomerPrefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private List<CustomerMain> _poolList;

    public void Start()
    {
        _poolList = new List<CustomerMain>();

        for (int i = 0; i < _poolSize; i++)
        {
            CustomerMain obj = Instantiate(CustomerPrefab, this.transform);
            obj.gameObject.SetActive(false);
            _poolList.Add(obj);
        }
    }

    public CustomerMain GetObjectFromPool()
    {
        foreach (CustomerMain obj in _poolList)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return null;
    }
}
