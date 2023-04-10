using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public int collisionHealt = 10;
    public string collisionTag;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == collisionTag)
        { 
            Target health = coll.gameObject.GetComponent<Target>();
            health.SetHealth(collisionHealt);
            Destroy(gameObject);
        }
    }
}
