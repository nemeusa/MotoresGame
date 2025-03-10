using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _slowDuration;
    public float SlowDuration { get { return _slowDuration; } }
    [SerializeField] private float _slowAmount;
    public float SlowAmount { get { return _slowAmount; } }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("bullet detected collision");
        }

        //Interface

        IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeDamage(10);
            //Debug.Log("recibe daño");
        }
    }
}
