using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject bullet;
    int bulletDamage;

    bool canShoot;
    float shootingTimer;
    [SerializeField] float shootingSpeed = 1;

    [SerializeField] GameObject movement_Target;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        canShoot = true;
        shootingTimer = 0;

        bulletDamage = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingSpeed)
            {
                canShoot = true;
                shootingTimer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<BulletScript>().SetBulletDmg(bulletDamage);
            //movement_Target.transform.position = gameObject.transform.position;
            Destroy(newBullet, 5f);

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x > 0)
            {
                spriteRenderer.flipX=false;
            }

        }
    }
}
