using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Ennemy_AI : MonoBehaviour
{
    Rigidbody rb;
    SpriteRenderer spriteRenderer;

    float distanceFromPlayer;
    [SerializeField] GameObject enemyProjectile;

    int enemySpeed = 3;
    float enemyAttack;
    float enemyHealth;

    bool canAttack;

    float attackCooldown;
    float attackTimer;

    int currentDay;

    GameObject Player;
    [SerializeField] GameObject Heart;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Player = GameObject.FindWithTag("Player").gameObject;

        currentDay = GameManagerScript.instance.GetDayCount();

        enemyAttack = 25;
        enemyHealth = 50;

        ScaleToDay();

        canAttack = true;
        attackCooldown = 3f;
        attackTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(Player.transform.position, gameObject.transform.position);

        if (distanceFromPlayer > 6)
        {
            Vector3 enemy_Movement = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, enemySpeed * Time.deltaTime);
            gameObject.transform.position = enemy_Movement;
        }
        else if (canAttack)
        {
            Attack();
        }

        if (!canAttack)
        {
            attackTimer = attackTimer + Time.deltaTime;

            if (attackTimer > attackCooldown)
            {
                canAttack = true;
                attackTimer = 0;

            }
        }

        if (gameObject.transform.position.x < Player.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (gameObject.transform.position.x > Player.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }


        if (enemyHealth <= 0)
        {
            if (Random.Range(0, 99) < 20)
            {
                Instantiate(Heart, gameObject.transform.position, Quaternion.identity);
            }

            PlayerPrefs.SetInt("kills", PlayerPrefs.GetInt("kills") + 1);
            PlayerPrefs.Save();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHealth(enemyAttack);
        }
    }

    public void EnemyLoseHealth(int dmg)
    {
        enemyHealth = enemyHealth - dmg;
        PlayerPrefs.SetInt("dmgDealt", PlayerPrefs.GetInt("dmgDealt") + dmg);
        PlayerPrefs.Save();
    }

    public void ScaleToDay()
    {
;
        for (int i = 1; i < currentDay; i++)
        {
            enemyHealth = Mathf.RoundToInt(enemyHealth * 1.2f);
            enemyAttack = Mathf.RoundToInt(enemyAttack * 1.2f);
        }
    }
    private void Attack()
    {
        GameObject newProjectile = Instantiate(enemyProjectile, gameObject.transform.position, Quaternion.identity);


        newProjectile.GetComponent<ProjScript>().SetProjData(enemyAttack);
        Destroy(newProjectile, 10 );

        canAttack = false;
    }
}
