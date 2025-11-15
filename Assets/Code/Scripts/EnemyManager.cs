using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] int initialWave;
    [SerializeField] EnemySpawner enemySpawner1;
    [SerializeField] EnemySpawner enemySpawner2;
    [SerializeField] EnemySpawner enemySpawner3;

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

    private int enemysSpawned = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("initialWave: " + initialWave);
        Waves(initialWave);
    }

    void Waves(int initialWave)
    {
        enemysSpawned = 1;
        Debug.Log("Waves - initialWave: " + initialWave);
        switch (initialWave)
        {
            case 1:
                StartCoroutine(LoadWave1());
                break;
            case 2:
                StartCoroutine(LoadWave2());
                break;
            case 3:
                StartCoroutine(LoadWave3());
                break;
            case 4:
                StartCoroutine(LoadWave4());
                break;
            case 5:
                StartCoroutine(LoadWave5());
                break;
            case 6:
                StartCoroutine(LoadWave6());
                break;
            case 7:
                StartCoroutine(LoadWave7());
                break;
            case 8:
                StartCoroutine(LoadWave8());
                break;
            case 9:
                StartCoroutine(LoadWave9());
                break;
            case 10:
                StartCoroutine(LoadWave10());
                break;
        }
    }
    IEnumerator LoadWave1()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave1);
        if (enemysSpawned < 3) 
        {
            enemysSpawned++;
            StartCoroutine(LoadWave1());
        }
        
    }

    IEnumerator LoadWave2()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave2);
        enemySpawner2.Spawn(patrolPoints2_Wave2);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave2());
        }

    }

    IEnumerator LoadWave3()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner1.Spawn(patrolPoints1_Wave3);
        if (enemysSpawned < 3)
        {
            enemysSpawned++;
            StartCoroutine(LoadWave3());
        }

    }

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

    }
    // Update is called once per frame
    void Update()
    {
        //Check if there are enemys still alive
        /*enemyStillAlive = GameObject.FindGameObjectWithTag("Enemy");
        if (!enemyStillAlive)
        {
            initialWave++;
            Waves(initialWave); 
        }*/
    }
}
