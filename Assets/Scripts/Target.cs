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

            /*
            switch (health)
            {
                case 90:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 80:
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 70:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 60:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 50:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 40:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 30:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 20:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 10:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
            }
            */
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