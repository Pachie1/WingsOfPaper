using System;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns;
    private float timeSinceLastSpawn;


    [SerializeField] private Enemy enemyPrefab;
    private IObjectPool<Enemy> enemyPool;


    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(CreateEnenmy);
    }

    private void GetObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);

        Transform spawnPoint = spawnPoints[0];
        enemy.transform.position = spawnPoint.position;
    }

    private void ReleaseObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Enemy CreateEnenmy()
    {
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.SetPool(enemyPool);
        return enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSinceLastSpawn)
        {
            enemyPool.Get();
            timeSinceLastSpawn = Time.time + timeSinceLastSpawn;
        }
    }
}
