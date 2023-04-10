using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        float hor = Input.GetAxis("Mouse X");
        //float ver = Input.GetAxis("Mouse Y");
        //transform.RotateAround(player.transform.position, Vector3.up, hor * 300 * Time.deltaTime);

    }


}
