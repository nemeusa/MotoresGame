using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public LightActive LightController;
    private bool LightState = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LightState = !LightState;
            LightController.Activate(LightState);
        }
    }
}
