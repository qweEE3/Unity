using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBuilding : MonoBehaviour
{
    [SerializeField] public GameObject template;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("update: " + hit.point);
                Vector3 position = new Vector3(hit.point.x, 1, hit.point.z);

                SpawnBuilding(position);
            }
        }
    }


    void SpawnBuilding(Vector3 position)
    {
        GameObject wall = Instantiate(template, position, Quaternion.identity);
        wall.transform.parent = transform;
        wall.AddComponent<EditBuilding>();
        Debug.Log("SpawnBuilding: " + wall.transform.position);
    }
}
