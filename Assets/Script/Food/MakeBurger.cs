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
                }
            }
        }

    }

    public void CreateBurger()
    {
        GameObject go = Instantiate(_burger, _burgerIngredients[0].transform.position, Quaternion.Euler(0, 90, 0));
        go.name = _burger.name;

        for(int i = 0; i < _burgerIngredients.Count; i++)
        {
            _burgerIngredients[i].gameObject.SetActive(false);
        }

        _burgerIngredients.RemoveRange(0, _burgerIngredients.Count);
    }

    public void IngredientAdded()
    {
        if (_burgerIngredients.Count == _burgerRecipe.Count)
        {
            CreateBurger();
        }
    }
}
