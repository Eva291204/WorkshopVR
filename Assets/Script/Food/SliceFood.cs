using System.Collections.Generic;
using UnityEngine;

public class SliceFood : MonoBehaviour
{
    [SerializeField] public List<GameObject> _foodToSlice = new List<GameObject>();
    [SerializeField] private List<GameObject> _foodSlice = new List<GameObject>();
    public bool CanSlice;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (CanSlice)
            {
                if (collision.gameObject.name == _foodToSlice[0].name) //cow
                {
                    Instantiate(_foodSlice[0]);
                    _foodSlice[0].transform.position = collision.transform.position;
                    Destroy(collision.gameObject);
                }

                for (int i = 1; i < _foodToSlice.Count; i++)
                {
                    if (collision.gameObject.name == _foodToSlice[i].name)
                    {

                        Instantiate(_foodSlice[i]);
                        Instantiate(_foodSlice[i]);
                        _foodSlice[i].transform.position = collision.transform.position;
                        Destroy(collision.gameObject);
                    }
                }
                CanSlice = false;
            }
        }
    }
}
