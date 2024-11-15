using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float speedDefaul;
    [SerializeField] float currentSpeed;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float fireRate = 1f;
    private float nextFireTime = 0f;

    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.forward * speedDefaul * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speedDefaul * Time.deltaTime);
        }

        if (transform.position.z >= rightLimit)
        {
            movingRight = false;
        }
        else if (transform.position.z <= leftLimit)
        {
            movingRight = true;
        }
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }


    public void Slow(float amount, float duration)
    {
        speedDefaul *= amount;
        Invoke(nameof(ResetSpeed), duration);
    }

    private void ResetSpeed() { currentSpeed = speedDefaul; }

    public void IsDead()
    {
        Destroy(gameObject);
    }
}
