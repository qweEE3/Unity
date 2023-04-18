using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMode : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform gun;
    private string mode = "";
    void Start()
    {
        gun = transform.Find("Gun");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildMode()
    {
        mode = "Build";
        gun.GetComponent<Gun>().enabled = false;
    }

    public void stopBuildMode()
    {
        mode = "";
        gun.GetComponent<Gun>().enabled = true;
    }

    public string Mode
    {
        get { return mode; }
    }
}
