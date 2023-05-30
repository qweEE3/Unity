using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageWall : MonoBehaviour
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
                TargetWall health = coll.gameObject.GetComponent<TargetWall>();
                health.TakeDamage(collisionDamage);
            }
        }
    }
}
