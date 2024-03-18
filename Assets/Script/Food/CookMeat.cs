using UnityEngine;
using System.Collections;
public class CookMeat : MonoBehaviour
{
    [SerializeField] private FoodSpawn _foodSpawn;
    [SerializeField] private GameObject _steak;
    [SerializeField] private GameObject _cookMeat;

    private GameObject collisionObject;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == _steak.name)
        {
            collisionObject = collision.gameObject;
            _foodSpawn.SpawnFood();
            StartCoroutine(MeatCook());
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == _steak.name)
        {
            _foodSpawn.StopCoroutine(_foodSpawn.WaitNewFoodSpawn());
            StopCoroutine(MeatCook());
            SoundManager.Instance.SoundCooktMeat.Stop();
        }
    }
    IEnumerator MeatCook()
    {
        SoundManager.Instance.PlayCooktMeatEffectSound();
        yield return new WaitForSeconds(_foodSpawn.WaitSpawn);
        Destroy(collisionObject);
    }
}
