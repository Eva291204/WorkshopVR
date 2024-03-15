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
                    GameObject go = Instantiate(_foodSlice[0]);
                    go.name = _foodSlice[0].name;

                    _foodSlice[0].transform.position = collision.transform.position;
                    Destroy(collision.gameObject);
                }

                for (int i = 1; i < _foodToSlice.Count; i++)
                {
                    if (collision.gameObject.name == _foodToSlice[i].name)
                    {
                        GameObject go2 = Instantiate(_foodSlice[i]);
                        GameObject go3 = Instantiate(_foodSlice[i]);
                        go2.name = _foodSlice[i].name;
                        go3.name = go2.name;
                        _foodSlice[i].transform.position = collision.transform.position;
                        Destroy(collision.gameObject);
                    }
                }
                CanSlice = false;
            }
        }
    }
}
