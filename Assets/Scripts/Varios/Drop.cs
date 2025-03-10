using UnityEngine;

public class Drop : Destruible
{
    public GameObject item;

    // Implementaci�n del m�todo abstracto DejarItem
    public override void DejarItem()
    {
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            Debug.Log("El objeto ha dejado un item: " + item.name);
        }
    }
}
