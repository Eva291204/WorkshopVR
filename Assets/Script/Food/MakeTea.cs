using System.Collections;
using UnityEngine;

public class MakeTea : MonoBehaviour
{
    [SerializeField] private FoodSpawn _foodSpawn;
    [SerializeField] private GameObject _emptyTea;
    [SerializeField] private GameObject _tea;
    [SerializeField] private GameObject _spawnPointTea;

    private GameObject collisionObject;
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == _emptyTea.name)
        {
            collisionObject = collision.gameObject;
            collision.gameObject.transform.position = _spawnPointTea.transform.position;
            _foodSpawn.SpawnFood();
            StartCoroutine(TeaMaker());
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == _emptyTea.name)
        {
            _foodSpawn.StopCoroutine(_foodSpawn.WaitNewFoodSpawn());
            StopCoroutine(TeaMaker());
        }
    }
    IEnumerator TeaMaker()
    {
        yield return new WaitForSeconds(_foodSpawn.WaitSpawn);
        Destroy(collisionObject);
    }
}
