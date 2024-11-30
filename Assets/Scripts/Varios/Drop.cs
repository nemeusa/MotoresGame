using UnityEngine;

public class Drop : Destruible
{
    public GameObject item;  // El objeto que dejar� al ser destruido

    // Implementaci�n del m�todo abstracto DejarItem
    public override void DejarItem()
    {
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);  // Deja el objeto en la posici�n del objeto destruido
            Debug.Log("El objeto ha dejado un item: " + item.name);
        }
    }
}
