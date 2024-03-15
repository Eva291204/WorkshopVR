using UnityEngine;

public class BurgerIngredients : MonoBehaviour
{
    [SerializeField] private MakeBurger _makeBurger;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tray"))
        {
            _makeBurger = collision.GetComponent<MakeBurger>();
            _makeBurger.CheckIngredient(this.gameObject);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tray"))
        {
            _makeBurger = collision.gameObject.GetComponent<MakeBurger>();
            _makeBurger.RemoveIngredient(this.gameObject);
        }
    }
}
