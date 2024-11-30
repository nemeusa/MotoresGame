using UnityEngine;

public class Drop : Destruible
{
    public GameObject item;  // El objeto que dejará al ser destruido

    // Implementación del método abstracto DejarItem
    public override void DejarItem()
    {
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);  // Deja el objeto en la posición del objeto destruido
            Debug.Log("El objeto ha dejado un item: " + item.name);
        }
    }
}
