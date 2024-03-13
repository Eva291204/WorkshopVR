using UnityEngine;

public class CustomerPlate : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            for(int i = 0; i < FoodManager.Instance.FoodList.Length; i++)
            {
                if(collision.gameObject.name == FoodManager.Instance.FoodList[i].Food.name)
                {
                    Debug.Log("présent dans la liste");
                    //check order
                }
            }
        }
    }
}
