using System.Collections.Generic;
using UnityEngine;

public class SliceFood : MonoBehaviour
{
    [SerializeField] public List<GameObject> _foodToSlice = new List<GameObject>();
    [SerializeField] private List<GameObject> _foodSlice = new List<GameObject>();
    public bool CanSlice;

    public void OnCollisionEnter(Collision collision)
    {

        if (CanSlice)
        {
            for (int i = 0; i < _foodSlice.Count; i++)
            {
                if (collision.gameObject.name == _foodToSlice[i].name)
                {
                    Instantiate(_foodSlice[i]);
                    Instantiate(_foodSlice[i]);
                    _foodSlice[i].transform.position = collision.transform.position;
                    Destroy(collision.gameObject);
                }
            }
            if (collision.gameObject.name == _foodToSlice[1].name) //cow
            {
                Instantiate(_foodSlice[1]);
                _foodSlice[1].transform.position = collision.transform.position;
                Destroy(collision.gameObject);
            }
            CanSlice = false;
        }
    }
}
