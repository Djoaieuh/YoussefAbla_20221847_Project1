using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 mouseWorldPos;
    Vector3 direction;

    float bulletSpeed;
    int bulletDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        mouseWorldPos.z = 0f;
        direction = mouseWorldPos;
        direction.Normalize();

        bulletSpeed = 18f;
    }

    void Update()
    {
        rb.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Ennemy_AI>().EnemyLoseHealth(bulletDamage);
            Destroy(gameObject);
        }
    }

    public void SetBulletDmg(int bulletdmg)
    {
        bulletDamage = bulletdmg;
    }
}
