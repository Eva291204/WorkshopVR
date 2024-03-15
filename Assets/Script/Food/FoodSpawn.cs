using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField]public int WaitSpawn;
    [SerializeField] private int _poolSize;
    private List<GameObject> _poolList;

    [SerializeField] private Spawner _spawner;
    private void Start()
    {
        _poolList = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_objectToSpawn);
            obj.name = _objectToSpawn.name;
            obj.SetActive(false);
            _poolList.Add(obj);
        }
    }
    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in _poolList)
        {
            if (!obj.activeInHierarchy)
            { return obj; }
        }
        return null;
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.name == _objectToSpawn.name)
        {
            StartCoroutine(WaitNewFoodSpawn());
        }
    }

    public void SpawnFood()
    {
        StartCoroutine(WaitNewFoodSpawn());
    }

    public IEnumerator WaitNewFoodSpawn()
    {
        yield return new WaitForSeconds(WaitSpawn);

        GameObject obj = GetObjectFromPool();
        if (obj != null)
        {
            obj.SetActive(true);
            _spawner.gameObjectToSpawn = obj;
            _spawner.SpawnGameObject();
        }
    }
}
