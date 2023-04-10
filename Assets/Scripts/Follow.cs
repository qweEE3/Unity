using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public float speed = 0.05f;
    public Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
    }
}
