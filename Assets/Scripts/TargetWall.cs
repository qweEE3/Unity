using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetWall : MonoBehaviour
{
    public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}