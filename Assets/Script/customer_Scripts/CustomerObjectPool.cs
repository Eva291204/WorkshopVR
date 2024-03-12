using System.Collections.Generic;
using UnityEngine;

public class CustomerObjectPool : MonoBehaviour
{
    public GameObject CustomerPrefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private List<GameObject> _poolList;

    public void Start()
    {
        _poolList = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(CustomerPrefab);
            obj.SetActive(false);
            _poolList.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in _poolList)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return null;
    }
}
