using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int salud;
    private bool estaVivo;

    public int Salud
    {
        get { return salud; }
        private set
        {
            salud = Mathf.Max(value, 0);
            if (salud == 0 && estaVivo)
            {
                Morir();
            }
        }
    }
    public bool EstaVivo
    {
        get { return estaVivo; }
    }

    void Start()
    {
        Salud = 50;  
        estaVivo = true;  
    }

    public void RecibirDanio(int danio)
    {
        if (estaVivo)
        {
            Salud -= danio;  
            Debug.Log("Enemigo recibió " + danio + " de daño. Salud actual: " + Salud);
        }
    }
       private void Morir()
    {
        estaVivo = false;
        Debug.Log("El enemigo ha muerto.");
        Destroy(gameObject);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            RecibirDanio(10);
            Debug.Log("¡El enemigo ha sido golpeado por una bala!");
        }
    }
}