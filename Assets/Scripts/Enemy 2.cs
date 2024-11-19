using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    //[SerializeField] float speedDefaul;
    //[SerializeField] float currentSpeed;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireRate = 1f;
    private float nextFireTime = 0f;

    private bool movingRight = true;

    private void Awake()
    {
        speedDefault = 10f;
        currentSpeed = 0.0f;
    }

    void Update()
    {
        //if (movingRight)
        //{
        //    transform.Translate(Vector3.forward * speedDefault * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector3.back * speedDefault * Time.deltaTime);
        //}

        Move(movingRight);

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

    private void OnTriggerEnter(Collider other)
    {
        Bullet2 bullet2 = other.GetComponent<Bullet2>();

        if (bullet2 != null)
        {
            IsDead();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }


    //public void Slow(float amount, float duration)
    //{
    //    speedDefaul *= amount;
    //    Invoke(nameof(ResetSpeed), duration);
    //}

    //private void ResetSpeed() { currentSpeed = speedDefaul; }

    //public void IsDead()
    //{
    //    Destroy(gameObject);
    //}
}
