using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentBuild : MonoBehaviour
{
    public string currentBuild;
    // Start is called before the first frame update
    void Start()
    {
        currentBuild = "wall";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            currentBuild = "turret";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentBuild = "wall";
        }
    }
}
