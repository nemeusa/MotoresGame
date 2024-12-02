using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting<T> : MonoBehaviour where T : Behaviour
{
    private T componente;

    void Awake()
    {
        componente = GetComponent<T>();

        if (componente == null)
        {
            Debug.LogError($"El componente {typeof(T).Name} no existe en {gameObject.name}");
        }
    }

    public void Activar(bool estado)
    {
        if (componente != null)
        {
            componente.enabled = estado;
        }
    }
}
