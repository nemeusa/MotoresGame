using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    public bool ChangeAlien;

    private void Update()
    {
        ChangePlayer();
    }
    void ChangePlayer()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            ChangeAlien = true;
        }
    }
}
