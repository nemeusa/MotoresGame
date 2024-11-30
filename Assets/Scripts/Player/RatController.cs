using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public bool ChangeRat;
    [SerializeField] float raycastMaxDistance;
    [SerializeField] LayerMask raycastMask;

    private void Update()
    {
        ChangePlayer();
    }

    void ChangePlayer()
    {
        if (Input.GetButtonDown("Vertical") && !Physics.Raycast
            (transform.position, Vector3.up, raycastMaxDistance, raycastMask))
        { 
            ChangeRat = true;
        }
    }
}
