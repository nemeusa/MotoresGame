using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] GameObject EnemyObject;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    //Enemy enemy = other.GetComponent<Enemy>();
    //    Enemy2 enemy2 = other.GetComponent<Enemy2>();

    //    if (enemy2 != null)
    //    {
    //        enemy2.IsDead();
    //    }
    //    Destroy(gameObject);     
    //    Debug.Log("choque xd");
    //}
}
