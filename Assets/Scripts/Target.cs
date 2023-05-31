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
    public Color MaxDamageColor = Color.white; 
    public Color MinDamageColor = Color.black; 

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

        if (gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(MaxDamageColor, MinDamageColor, health / maxHealth);
        }
        

    }

    void Die()
    {
        GameObject.FindGameObjectWithTag("spawner").GetComponent<SpawnEnemy>().checkEnemyOnMap();
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