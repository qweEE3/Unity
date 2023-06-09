using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 15f;
    public float range = 100f;
    public float force = 155;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public AudioClip shotSFX;
    public AudioSource _audioSource;
    public GameObject hitEffect;

    public Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //shoot forward
    private void Shoot()
    {
        _audioSource.PlayOneShot(shotSFX);
        muzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                if (target.health <= damage)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Bank>().currentBank += 2;
                }
                target.TakeDamage(damage);
            }
        }
    }
}
