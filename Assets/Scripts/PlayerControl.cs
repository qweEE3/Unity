using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    private float speed = 50;
    private Rigidbody rb;
    private GameObject camera;
    private GameObject testCube;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        //testCube = GameObject.FindGameObjectWithTag("TestCube");
        testCube = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        testCube.transform.position = camera.transform.position;        
        testCube.transform.rotation = new Quaternion(0, camera.transform.rotation.y, 0, camera.transform.rotation.w);        
        //var rotation = new Quaternion(0, camera.transform.rotation.y, 0, camera.transform.rotation.w);
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate((rotation.forward * Time.deltaTime) * speed, Space.World);
            transform.Translate((testCube.transform.forward * Time.deltaTime) * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-testCube.transform.forward * Time.deltaTime) * speed, Space.World);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((testCube.transform.right * Time.deltaTime) * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((-testCube.transform.right * Time.deltaTime) * speed, Space.World);
        }
    }
}
