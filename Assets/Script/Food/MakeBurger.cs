using System;
using System.Collections.Generic;
using UnityEngine;

public class MakeBurger : MonoBehaviour
{
    /// <summary>
    /// ingredients actuels
    /// </summary>
    public List<GameObject> _burgerIngredients = new List<GameObject>();
    /// <summary>
    /// ingredients requis
    /// </summary>
    [SerializeField] private List<GameObject> _burgerRecipe = new List<GameObject>();
    [SerializeField] private GameObject _burger;

    [SerializeField] private uint _burgerCurrentlyOnTable;
    
    public void CheckIngredient(GameObject go)
    {
        if (go.CompareTag("Food")) {
            for (int i = 0; i < _burgerRecipe.Count; i++) {
                if (go.name == _burgerRecipe[i].name) {
                    if (_burgerIngredients.Count > 0) {

                        bool ingredientAlreadyAdded = false;
                        for (int j = 0; j < _burgerIngredients.Count; j++)
                        {
                            if(go.name == _burgerIngredients[j].name)
                            {
                                ingredientAlreadyAdded = true;
                                break;
                            }
                        }

                        if(!ingredientAlreadyAdded)
                        {
                            _burgerIngredients.Add(go);
                            IngredientAdded();
                            break;
                        }
                    }
                    else {
                        _burgerIngredients.Add(go);
                        IngredientAdded();
                        break;
                    }
                }
            }
        }
    }

    public void RemoveIngredient(GameObject go)
    {
        if (go.CompareTag("Food"))
        {
            for (int i = 0; i < _burgerIngredients.Count; i++)
            {
                if (go.name == _burgerIngredients[i].name)
                {
                    _burgerIngredients.Remove(go);
                    _burgerCurrentlyOnTable--;
                }
            }
        }

    }

    public void CreateBurger()
    {
        Instantiate(_burger, _burgerIngredients[0].transform.position, Quaternion.Euler(0, 90, 0));
        for(int i = 0; i < _burgerIngredients.Count; i++)
        {

            Destroy(_burgerIngredients[i]);

        }
    }

    public void IngredientAdded()
    {
        _burgerCurrentlyOnTable++;
        if (_burgerCurrentlyOnTable == _burgerRecipe.Count)
        {
            CreateBurger();
            _burgerCurrentlyOnTable = 0;
        }
    }
}
