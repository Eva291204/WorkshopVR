using UnityEngine;

public class CheckSliceFood : MonoBehaviour
{
    [SerializeField] private SliceFood _sliceFood;

    public void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < _sliceFood._foodToSlice.Count; i++)
        {
            if(collision.gameObject.name == _sliceFood._foodToSlice[i].gameObject.name)
            {
                _sliceFood.CanSlice = true;
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        for (int i = 0; i == _sliceFood._foodToSlice.Count; i++)
        {
            if(collision.gameObject.name == _sliceFood._foodToSlice[i].gameObject.name)
            {
                _sliceFood.CanSlice = false;
            }
        }
    }
}
