using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject Player;

    float spawnerTimer;
    int spawnrate;

    float enemyXPos;
    float enemyYPos;


    void Start()
    {
        spawnerTimer = 0f;
        spawnrate = 2;

        enemyXPos = 0;
        enemyYPos = 0;
    }


    void Update()
    {
        if (spawnerTimer < spawnrate) 
        {
            spawnerTimer += Time.deltaTime;
        }
        else
        {
            enemyXPos = Random.Range(-1, 1) < 0
            ? Player.transform.position.x - 11 + Random.Range(-2, 0)
            : Player.transform.position.x + 11 + Random.Range(0, 2);

            enemyYPos = Random.Range(-1, 1) < 0
            ? Player.transform.position.y - 5 + Random.Range(-2, 0)
            : Player.transform.position.y + 5 + Random.Range(0, 2);

            GameObject newEnnemy = Instantiate(EnemyPrefab, new Vector3(enemyXPos, enemyYPos, 0), Quaternion.identity);
            spawnerTimer = 0f;
        }
    }
}
