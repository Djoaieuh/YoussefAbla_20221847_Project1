using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    float health;

    bool invulnerable;
    float invulnCooldown;
    float invulnTimer;


    void Start()
    {
        health = 100;

        invulnerable = false;
        invulnCooldown = 0.8f;
        invulnTimer = 0f;
    }

    void Update()
    {
        if (health <= 0)
        {
            GameManagerScript.instance.GameOver();
            PlayerPrefs.SetInt("nbOfDeaths", PlayerPrefs.GetInt("nbOfDeaths") + 1);
            PlayerPrefs.Save();
        }

        if (invulnerable)
        {
            invulnTimer += Time.deltaTime;

            if (invulnTimer > invulnCooldown)
            {
                invulnerable = false;
                invulnTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            health = health + 25;
            Destroy(collision.gameObject);
        }
    }

    public void LoseHealth(float dmg)
    {
        if (!invulnerable)
        {
            health -= dmg;
            invulnerable = true;

            PlayerPrefs.SetFloat("dmgTaken", PlayerPrefs.GetInt("dmgTaken") + dmg);
            PlayerPrefs.Save();
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
