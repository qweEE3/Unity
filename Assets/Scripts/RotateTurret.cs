using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateTurret : MonoBehaviour
{
    [SerializeField] public float maxDistance;
    [SerializeField] public float minDistance;
    private GameObject turretHead;
    private GameObject dulo;
    private GameObject target;
    public float damage = 20f;
    public float range = 100f;
    public float force = 155;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public AudioClip shotSFX;
    public AudioSource _audioSource;
    public GameObject hitEffect;

    [SerializeField] float shootDelay = 0.3f;
    float shootInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        turretHead = transform.GetComponentsInChildren<Transform>().Where(t => t.tag == "turretHead").ToArray()[0].gameObject;        
        dulo = turretHead.GetComponentsInChildren<Transform>().Where(t => t.tag == "dulo").ToArray()[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        target = FindClosestEnemy(maxDistance);
        if(target == null)
        {
            Debug.DrawRay(dulo.transform.position, dulo.transform.TransformDirection(Vector3.forward)*100, Color.red);
            return;
        }
        var pointToHead = target.transform.position - turretHead.transform.position;
        pointToHead.y = 0;
        turretHead.transform.rotation = Quaternion.LookRotation(pointToHead);

        var pointToDulo = target.transform.position - dulo.transform.position;
        if (pointToDulo.sqrMagnitude > 50)
        {
            dulo.transform.rotation = Quaternion.LookRotation(pointToDulo);

            RaycastHit hit;
            Ray ray = new Ray(dulo.transform.position, pointToDulo);
            Physics.Raycast(ray, out hit);
            if(hit.collider != null)
            {
                if(hit.collider.gameObject == target)
                {
                    Debug.DrawRay(dulo.transform.position, pointToDulo, Color.red);
                    Shoot(hit);
                }
            }


            //pointToDulo.x = pointToDulo.z = 0;
            //Debug.Log("magnitude: " + pointToDulo.sqrMagnitude);            
        }

        
    }
    private GameObject FindClosestEnemy(float maxDistance)
    {
        GameObject closest = null;
        List<GameObject> enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        float distance = Mathf.Infinity;
        float curDistance;
        if (enemyes.Count > 0)
        {
            foreach (GameObject go in enemyes)
            {
                Vector3 diff = go.transform.position - transform.position;
                curDistance = diff.sqrMagnitude;
                if (curDistance < distance && curDistance > minDistance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            if (distance <= maxDistance) return closest;
            else return null;
        }
        else return null;
    }

    private void Shoot(RaycastHit hit)
    {
        //GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroy(impact, 2f);


        if (shootInterval < shootDelay)
        {
            shootInterval += Time.deltaTime;
        } 
        
        else
        {
            Target target = hit.transform.GetComponent<Target>();
            _audioSource.PlayOneShot(shotSFX);
            muzzleFlash.Play();
            if (target != null)
            {
                if (target.health <= damage)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Bank>().currentBank += 1;
                }
                target.TakeDamage(damage);
                Debug.Log(target.health);
            }
            shootInterval = 0;
        }
        
    }
}
