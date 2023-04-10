using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;
    float elapsedTime = 0.0f;


    private void OnCollisionStay(Collision coll)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.5f)
        {
            elapsedTime = 0.0f;
            if (coll.gameObject.tag == collisionTag)
            {
                Target health = coll.gameObject.GetComponent<Target>();
                health.TakeDamage(collisionDamage);
            }
        }
    }
}
