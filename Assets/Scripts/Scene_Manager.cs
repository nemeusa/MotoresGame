using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CambiarMuseo();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            CambiarMovimiento();
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeBear();
        }
    }

    public void CambiarMuseo()
    {
        SceneManager.LoadScene("Museo");
    }
    public void CambiarMovimiento()
    {
        SceneManager.LoadScene("Movimiento");
    }

    public void ChangeBear()
    {
        SceneManager.LoadScene("Bear");
    }
}
