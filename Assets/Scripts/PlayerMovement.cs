using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header ("move")]
    [SerializeField] float speedMov;
    Rigidbody rb;

    [Header ("Jump")]
    [SerializeField] float forceJump;
    //[SerializeField] float extraForceJump;
    [Range(0,1)][SerializeField] float jumpTime;
    private float jumpTimeCounter;
    private bool isJump;
    private bool isJumping;
    private bool takeFloor;
    
    [SerializeField] float gravityMultiplier;
    [SerializeField] float gravityMultiplierUp;

    [SerializeField] float raycastMaxDistance;
    [SerializeField] LayerMask raycastMask;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Move();
        Jump();
    }
     private void Update()
    {
        if (Input.GetButtonDown("Jump") && takeFloor)
        {
            isJump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }


    void Move()
    {
        float dir = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, dir * speedMov);

        //var Dir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * speedMov);

        //Dir = Dir * speedMov * Time.deltaTime * speedMov;
        //rb.MovePosition(transform.position + Dir * speedMov * Time.fixedDeltaTime);

        if(dir > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if(dir < 0) transform.rotation = Quaternion.Euler(0, 180, 0);

    }


    void Jump()
    {

        takeFloor = Physics.Raycast(transform.position, Vector3.down, raycastMaxDistance, raycastMask);
        

        if (isJump)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            //rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime);
            isJump = false;

        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.fixedDeltaTime;
                rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime, ForceMode.Impulse);
                //rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime);
            }
        }

        if (rb.velocity.y > 0) rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplierUp / 2), ForceMode.Acceleration);

        if (!takeFloor && rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplier - 1), ForceMode.Acceleration);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastMaxDistance);
    }
}
