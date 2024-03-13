using System.Collections.Generic;
using UnityEngine;

public class SliceFood : MonoBehaviour
{
    [SerializeField] private List<GameObject> _foodToSlice = new List<GameObject>();
    [SerializeField] private List<GameObject> _foodSlice = new List<GameObject>();

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == _foodToSlice[0].name) // pasteque
        {
            Destroy(collision.gameObject);
            Instantiate(_foodSlice[0]);
            Instantiate(_foodSlice[0]);
            _foodSlice[0].transform.position = collision.transform.position;
        }
        else if (collision.gameObject.name == _foodToSlice[1].name) //cow
        {
            Destroy(collision.gameObject);
            Instantiate(_foodSlice[1]);
            _foodSlice[1].transform.position = collision.transform.position;
        }
    }
}
