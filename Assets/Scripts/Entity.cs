using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float speedDefault;
    [SerializeField] protected float currentSpeed;
    [SerializeField] protected float health;

    public void Slow(float amount, float duration)
    {
        currentSpeed = speedDefault / amount;

        Debug.Log("velocidad actual del enemigo: " + currentSpeed + "/" + speedDefault);

        Invoke(nameof(ResetSpeed), duration);
    }

    protected void ResetSpeed() { currentSpeed = speedDefault; }

    public void Move()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    public void Move(bool movRight)
    {
        if (movRight)
        {
            transform.Translate(Vector3.forward * speedDefault * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speedDefault * Time.deltaTime);
        }
    }

    public void IsDead()
    {
        Debug.Log("enemigo: X_X");
        Destroy(gameObject);
    }
}
