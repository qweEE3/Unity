using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //shoot forward
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.point);
            Debug.DrawRay(transform.position, hit.point - transform.position, Color.green, 5);
            if (hit.transform.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
            }

        }
    }
}
