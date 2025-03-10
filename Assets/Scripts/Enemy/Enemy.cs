using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health;
    private bool estaVivo;

    public int Healt
    {
        get { return _health; }
        private set
        {
            _health = Mathf.Max(value, 0);
            if (_health == 0 && estaVivo)
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
        Healt = 50;  
        estaVivo = true;  
    }

    public void TakeDamage(int Damage)
    {
        if (estaVivo)
        {
            Healt -= Damage;  
            Debug.Log("Enemigo recibió " + Damage + " de daño. Salud actual: " + Healt);
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
            TakeDamage(10);
            Debug.Log("¡El enemigo ha sido golpeado por una bala!");
        }
    }
}