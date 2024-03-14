using UnityEngine;

public class BurgerIngredients : MonoBehaviour
{
    [SerializeField] private MakeBurger _makeBurger;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tray"))
        {
            _makeBurger.CheckIngredient(this.gameObject);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tray"))
        {
            _makeBurger.RemoveIngredient(this.gameObject);
        }
    }
}
