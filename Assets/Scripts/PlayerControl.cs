using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 35;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(transform.position.y > 1.3)
        {
            var position = transform.position;
            position.y = 1;
            transform.position = position;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.z > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
        }
        if (!Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.z < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
        }
        if (!Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }
        if (!Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);         
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 0);            
        }
    }
}
