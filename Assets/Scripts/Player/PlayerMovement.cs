using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Move")]
    [SerializeField] float speedMov;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float dir = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, dir * speedMov);
        if(dir > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if(dir < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
