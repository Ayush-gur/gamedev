using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public float movespeed = 2.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, 0, zInput) * movespeed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;

        Vector3 facingDir = new Vector3(xInput, 0, zInput);
        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            checkJumpForce();
        }
    }
    void checkJumpForce()
    {
        rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
    }
}
