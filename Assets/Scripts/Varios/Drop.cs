using UnityEngine;

public class Drop : Destruible
{
    public GameObject item;

    // Implementación del método abstracto DejarItem
    public override void DejarItem()
    {
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            Debug.Log("El objeto ha dejado un item: " + item.name);
        }
    }
}
