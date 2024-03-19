using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour
{
    Rigidbody2D rb;

    GameObject Player;

    float projDamage;
    Vector3 directionToPlayer;

    int projSpeed;



    void Start()
    {
        projSpeed = 7;
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.FindWithTag("Player").gameObject;

        directionToPlayer = (Player.transform.position - transform.position).normalized;
        rb.velocity = directionToPlayer * projSpeed;
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHealth(projDamage);
            Destroy(gameObject);
        }
    }

    public void SetProjData(float damage)
    { 
        projDamage = damage;
    }
}
