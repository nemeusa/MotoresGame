using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting<T> : MonoBehaviour where T : Behaviour
{
    private T _component;

    void Awake()
    {
        _component = GetComponent<T>();

        if (_component == null)
        {
            Debug.LogError($"El componente {typeof(T).Name} no existe en {gameObject.name}");
        }
    }

    public void Activate(bool estado)
    {
        if (_component != null)
        {
            _component.enabled = estado;
        }
    }
}
