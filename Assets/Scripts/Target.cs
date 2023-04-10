using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Target : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image LineBar;
    public TMP_Text playerHealthText;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (gameObject.tag == "Player")
        {
            LineBar.fillAmount = health / 100;
            playerHealthText.text = health + "%";
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        LineBar.fillAmount = health / 100;
        playerHealthText.text = health + "%";

        if (health > maxHealth)
        {
            health = maxHealth;
            playerHealthText.text = maxHealth + "%";
        }
    }
}