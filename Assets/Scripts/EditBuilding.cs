using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EditBuilding : MonoBehaviour
{
    float maxDistance;
    float distance;
    GameObject player;
    Renderer render;
    Color oldColor;
    int scrollSense = 15;
    bool isTouches;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        maxDistance = GameObject.Find("Plane").GetComponent<AddBuilding>().maxDistance;
        render = transform.Find("Cube").GetComponent<MeshRenderer>();
        oldColor = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 position = new Vector3(hit.point.x, 1, hit.point.z);
            transform.position = position;

            //изменить цвет если стенка далеко от игрока или соприкасается с другой стенкой
            distance = (position - player.transform.position).magnitude;
            isTouches = false;
            foreach (var item in Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity))
            {
                if (item.name == "Cube" || item.name == "Wall(Clone)")
                {
                    isTouches = true;
                    break;
                }
            }

            if (distance > maxDistance || isTouches)
            {
                render.material.SetColor("_Color", new Color(0, 0, 0));
            }
            else
            {
                render.material.SetColor("_Color", oldColor);
            }
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
            if (distance < maxDistance && !isTouches)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
                transform.Find("Cube").GetComponent<BoxCollider>().enabled = true;
                Destroy(GetComponent<EditBuilding>());
                player.GetComponent<ActiveMode>().stopBuildMode();
            }
        }
    }
}
