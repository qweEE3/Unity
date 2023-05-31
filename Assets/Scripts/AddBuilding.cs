using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddBuilding : MonoBehaviour
{
    [SerializeField] public GameObject wallTemplate;
    [SerializeField] public GameObject turretTemplate;
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
        var bank = player.GetComponent<Bank>();
        if (player.GetComponent<CurrentBuild>().currentBuild == "wall")
        {
            if (bank.currentBank < bank.priceWall)
            {
                player.GetComponent<ActiveMode>().stopBuildMode();
                return;
            }
            bank.currentBank -= bank.priceWall;
            GameObject wall = Instantiate(wallTemplate, position, Quaternion.identity);
            wall.transform.parent = transform;
            wall.GetComponent<BoxCollider>().enabled = false;
            wall.transform.Find("Cube").GetComponent<BoxCollider>().enabled = false;
            wall.AddComponent<EditBuilding>();
        } 
        else
        {
            if (bank.currentBank < bank.priceTurret)
            {
                player.GetComponent<ActiveMode>().stopBuildMode();
                return;
            }
            bank.currentBank -= bank.priceTurret;
            GameObject turret = Instantiate(turretTemplate, position, Quaternion.identity);
            turret.GetComponent<Rigidbody>().mass = 0;
            turret.transform.parent = transform;            
            turret.transform.Find("Cube (1)").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (2)").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (3)").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (3)").Find("Cube (6)").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (3)").Find("Cube").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (3)").Find("Cube (6)").Find("Cylinder").GetComponent<CapsuleCollider>().enabled = false;
            turret.transform.Find("Cube (3)").Find("Cube (6)").Find("Cylinder").Find("dulo").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (4)").GetComponent<BoxCollider>().enabled = false;
            turret.transform.Find("Cube (5)").GetComponent<BoxCollider>().enabled = false;
            turret.AddComponent<EditBuilding>();
        }
    }


    
}
