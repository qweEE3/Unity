using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddBuilding : MonoBehaviour
{
    [SerializeField] public GameObject template;
    [SerializeField] public float maxDistance;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<ActiveMode>().Mode == "Build")
            return;

        if (Input.GetButtonDown("Fire2"))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 position = new Vector3(hit.point.x, 1, hit.point.z);

                //расстояние от точки клика до игрока
                var distance = (position - player.transform.position).magnitude;
                Debug.Log(distance < maxDistance);

                if (distance < maxDistance)
                {
                    Debug.Log("q");
                    GameObject.Find("Player").GetComponent<ActiveMode>().BuildMode();
                    SpawnBuilding(position);
                }
            }
        }
    }


    void SpawnBuilding(Vector3 position)
    {
        GameObject wall = Instantiate(template, position, Quaternion.identity);
        wall.transform.parent = transform;
        wall.GetComponent<BoxCollider>().enabled = false;
        wall.transform.Find("Cube").GetComponent<BoxCollider>().enabled = false;
        wall.AddComponent<EditBuilding>();
    }
}
