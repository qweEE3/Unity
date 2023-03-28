using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditBuilding : MonoBehaviour
{

    int scrollSense = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        

        Debug.Log("work");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {            
            Vector3 position = new Vector3(hit.point.x, 1, hit.point.z);
            transform.position = position;
        }              

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.up * scrollSense, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.down * scrollSense, Space.Self);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(GetComponent<EditBuilding>());
        }
    }
}
