using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private int _waitSpawn;
    [SerializeField] private int _poolSize;
    private List<GameObject> poolList;

    [SerializeField] private Spawner MeatSpawner;
    private void Start()
    {
        poolList = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_objectToSpawn);
            obj.SetActive(false);
            poolList.Add(obj);
        }
    }
    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in poolList)
        {
            if (!obj.activeInHierarchy)
            { return obj; }
        }
        return null;
    }

    public void OnTriggerExit(Collider collider)
    {
        StartCoroutine(WaitNewFoodSpawn());
    }

    IEnumerator WaitNewFoodSpawn()
    {
        yield return new WaitForSeconds(_waitSpawn);

        GameObject obj = GetObjectFromPool();
        if (obj != null)
        {
            obj.SetActive(true);
            MeatSpawner.gameObjectToSpawn = obj;
            MeatSpawner.SpawnGameObject();
        }
    }
}
