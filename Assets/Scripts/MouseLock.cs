using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseCamera
{
    public class MouseLock : MonoBehaviour
    {
        public float mouseSens = 100f;
        public Transform playerBody;
        float rotation = 0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            rotation += mouseX;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}
