using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviour : MonoBehaviour
{
    public Rigidbody rb;

    public float moveDirection;
    private bool moving = false;
    public float speed = 100f;

    public float jumpForce;
    public float atackForce;

    public int bees = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveDirection = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.AddForce(transform.forward * moveDirection);

        if (Input.GetKeyDown(KeyCode.W))
        {
            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector3(0, jumpForce, moveDirection);
            moving = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector3(0, atackForce, moveDirection);
            moving = true;
        }
    }
}
