using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedDefaul;
    [SerializeField] public float currentSpeed;

    private void Start()
    {
        currentSpeed = speedDefaul;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            Slow(bullet.SlowAmount, bullet.SlowDuration);
            Debug.Log("Enemy received collision");
        }
    }

    public void Slow (float amount, float duration) 
    {
        currentSpeed = speedDefaul / amount;

        Invoke(nameof(ResetSpeed), duration);
    }

    private void ResetSpeed(){ currentSpeed = speedDefaul; }
}
