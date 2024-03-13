using System.Collections.Generic;
using UnityEngine;

public class MakeBurger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _burgerIngredients = new List<GameObject>();
    [SerializeField] private int _ingredientOnTable;
    [SerializeField] private GameObject _burger;
    public void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < _burgerIngredients.Count; i++)
        {
            if (collision.gameObject.name == _burgerIngredients[i].name)
            {
                _ingredientOnTable++;
                Debug.Log(_ingredientOnTable);
            }
            if(_ingredientOnTable == _burgerIngredients.Count)
            {
                Instantiate(_burger);
                _burger.transform.position = collision.transform.position;
                Destroy(collision.gameObject);
            }
        }
    }
}
