using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private float Y;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Y = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;
        direction = direction.normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void FixedUpdate()
    {        

    }

    private void Walk()
    {
        
    }
}
