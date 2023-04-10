using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RotatePlayer : MonoBehaviour
{    
    GameObject playerGun;
    void Start()
    {
        playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            RayFromPlayer(hit.point);

            Vector3 direction = hit.point-transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);            
            Debug.DrawRay(ray.origin, hit.point-ray.origin, Color.green);
        }
    }


    //cast ray from gun on player
    void RayFromPlayer(Vector3 position)
    {        
        position.y = playerGun.transform.position.y;
        position = position - playerGun.transform.position;
        Debug.DrawRay(playerGun.transform.position, position, Color.magenta);
    }
}
