using UnityEngine;

public class Vacio : Destruible
{
    public override void DejarItem()
    {
        Debug.Log("El objeto vac�o no ha dejado nada.");
    }
}