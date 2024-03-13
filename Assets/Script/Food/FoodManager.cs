using System;
using UnityEngine;

[Serializable]
public class FoodManager : MonoBehaviour
{
    private static FoodManager _foodInstance;
    public static FoodManager Instance
    {
        get
        {
            if (_foodInstance == null)
            {
                Debug.Log("FoodManager is null");
            }
            return _foodInstance;
        }
    }
    public void Awake()
    {
        if (_foodInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _foodInstance = this;
        }
    }

    public FoodStruct[] FoodList;
}

[Serializable]
public struct FoodStruct
{
    public int NumberTag;
    public GameObject Food;
    public Sprite FoodSprite;
}
