using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public int initialWave;
    [SerializeField] public EnemySpawner enemySpawner1;
    [SerializeField] public EnemySpawner enemySpawner2;
    [SerializeField] public EnemySpawner enemySpawner3;

    [Header("Wave1")]
    public Transform[] patrolPoints1_Wave1;

    [Header("Wave2")]
    public Transform[] patrolPoints1_Wave2;
    public Transform[] patrolPoints2_Wave2;

    [Header("Wave3")]
    public Transform[] patrolPoints1_Wave3;

    [Header("Wave4")]
    public Transform[] patrolPoints1_Wave4;
    public Transform[] patrolPoints2_Wave4;

    [Header("Wave5")]
    public Transform[] patrolPoints1_Wave5;
    public Transform[] patrolPoints2_Wave5;

    [Header("Wave6")]
    public Transform[] patrolPoints1_Wave6;
    public Transform[] patrolPoints2_Wave6;

    [Header("Wave7")]
    public Transform[] patrolPoints1_Wave7;
    public Transform[] patrolPoints2_Wave7;

    [Header("Wave8")]
    public Transform[] patrolPoints1_Wave8;
    public Transform[] patrolPoints2_Wave8;

    [Header("Wave9")]
    public Transform[] patrolPoints1_Wave9;
    public Transform[] patrolPoints2_Wave9;

    [Header("Wave10")]
    public Transform[] patrolPoints1_Wave10;
    public Transform[] patrolPoints2_Wave10;
    public Transform[] patrolPoints3_Wave10;

    private GameObject enemyStillAlive;
    private StartGame canva;


    [SerializeField] private float spawnDelay = 0.5f;   
    [SerializeField] private int spawnsPerWave = 3; 

    private int currentWave;
    private int spawnsDoneInCurrentWave = 0;
    private float nextSpawnTime = 0f;

    private int enemysLeft = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemysLeft = 0;
        currentWave = initialWave;
        SetupWave(currentWave);
    }

   
    void LoadWave1()
    { 
        enemySpawner1.Spawn(patrolPoints1_Wave1);
    }

    void LoadWave2()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave2);
        enemySpawner2.Spawn(patrolPoints2_Wave2);
    }

    void LoadWave3()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave3);
    }
    /*
    IEnumerator LoadWave4()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave4);
        enemySpawner2.Spawn(patrolPoints2_Wave4);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave4());
        }

    }

    IEnumerator LoadWave5()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave5);
        enemySpawner2.Spawn(patrolPoints2_Wave5);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave5());
        }

    }

    IEnumerator LoadWave6()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave6);
        enemySpawner2.Spawn(patrolPoints2_Wave6);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave6());
        }

    }

    IEnumerator LoadWave7()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave7);
        enemySpawner2.Spawn(patrolPoints2_Wave7);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave7());
        }

    }

    IEnumerator LoadWave8()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave8);
        enemySpawner2.Spawn(patrolPoints2_Wave8);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave8());
        }

    }

    IEnumerator LoadWave9()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave9);
        enemySpawner2.Spawn(patrolPoints2_Wave9);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave9());
        }

    }

    IEnumerator LoadWave10()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave10);
        enemySpawner2.Spawn(patrolPoints2_Wave10);
        enemySpawner3.Spawn(patrolPoints3_Wave10);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave10());
        }

    }*/
    // Update is called once per frame

    public void enemyHasDied()
    {
        enemysLeft--;
        Debug.Log("enemyHasDied - enemysLeft: " + enemysLeft); 
        if (enemysLeft == 0) 
        {
            initialWave++;

            currentWave++;
            initialWave = currentWave; 
            SetupWave(currentWave);
        }
    }

    public void enemyHasSpawned()
    {
        enemysLeft++;
        Debug.Log("enemyHasSpawned - enemysLeft: " + enemysLeft);
    }

    void Update()
    {
        HandleWaveSpawning();
    }

    private void SetupWave(int waveNumber)
    {
        enemysLeft = 0;
        spawnsDoneInCurrentWave = 0;
        nextSpawnTime = Time.time + spawnDelay;
    }

    private void HandleWaveSpawning()
    {
        Debug.Log("HandleWaveSpawning - spawnsDoneInCurrentWave: " + spawnsDoneInCurrentWave); 
        Debug.Log("HandleWaveSpawning - spawnsPerWave: " + spawnsPerWave);
        if (spawnsDoneInCurrentWave >= spawnsPerWave)
            return;

        Debug.Log("HandleWaveSpawning - nextSpawnTime: " + nextSpawnTime);
        if (Time.time < nextSpawnTime)
            return;

        Debug.Log("HandleWaveSpawning - currentWave: " + currentWave);
        switch (currentWave)
        {
            case 1:
                LoadWave1();
                break;
            case 2:
                LoadWave2();
                break;
            case 3:
                LoadWave3();
                break;
                // case 4: SpawnWave4Pattern(); ...
        }

        spawnsDoneInCurrentWave++;
        nextSpawnTime = Time.time + spawnDelay;
    }

}
