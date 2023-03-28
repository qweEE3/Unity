using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public GameObject Template;
    private float minPointX;
    private float minPointZ;
    private float maxPointX;
    private float maxPointZ;
    private readonly float Y = 1;


    // Start is called before the first frame update
    void Start()
    {
        var mesh = GetComponent<MeshCollider>();
        minPointX = transform.position.x - mesh.bounds.size.x / 2;
        minPointZ = transform.position.z - mesh.bounds.size.z / 2;
        maxPointX = transform.position.x + mesh.bounds.size.x / 2;
        maxPointZ = transform.position.z + mesh.bounds.size.z / 2;

        /*Vector3 position = new Vector3(Random.Range(minPointX, maxPointX), Y, Random.Range(minPointZ, maxPointZ));
        Collider[] intersecting = Physics.OverlapSphere(position, 2);
        foreach (var item in intersecting) Debug.Log(item);*/
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(minPointX, maxPointX), Y, Random.Range(minPointZ, maxPointZ));
            GameObject enemy = Instantiate(Template, position, Quaternion.identity);
            enemy.transform.parent = transform;
            enemy.tag = "Enemy";

            yield return new WaitForSeconds(1);
        }
    }
}
