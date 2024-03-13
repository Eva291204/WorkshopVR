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
            if (collision.gameObject.name == _foodToSlice[0].name) // pasteque
            {
                Instantiate(_foodSlice[0]);
                Instantiate(_foodSlice[0]);
                _foodSlice[0].transform.position = collision.transform.position;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == _foodToSlice[1].name) //cow
            {
                Instantiate(_foodSlice[1]);
                _foodSlice[1].transform.position = collision.transform.position;
                Destroy(collision.gameObject);
            }
            CanSlice = false;
        }
    }
}
