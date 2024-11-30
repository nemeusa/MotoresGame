using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    public enum HealthStatus
    {
        Full, //Full vida   
        Damage, //Recibió daño
        Dead,  //muelto
        Inmunity, //No puede recibir daño
    }
}
