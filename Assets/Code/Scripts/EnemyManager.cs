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

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Level level;

    public int currentWave;
    private int spawnsDoneInCurrentWave = 0;
    private float nextSpawnTime = 0f;
    private bool wave10MusicPlayed = false;


    void Start()
    {
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

    void LoadWave4()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave4);
        enemySpawner2.Spawn(patrolPoints2_Wave4);
    }

    void LoadWave5()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave5);
        enemySpawner2.Spawn(patrolPoints2_Wave5);
    }

    void LoadWave6()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave6);
        enemySpawner2.Spawn(patrolPoints2_Wave6);
    }

    void LoadWave7()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave7);
        enemySpawner2.Spawn(patrolPoints2_Wave7);
    }

    void LoadWave8()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave8);
        enemySpawner2.Spawn(patrolPoints2_Wave8);
    }

    void LoadWave9()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave9);
        enemySpawner2.Spawn(patrolPoints2_Wave9);
    }

    void LoadWave10()
    {
        enemySpawner1.Spawn(patrolPoints1_Wave10);
        enemySpawner2.Spawn(patrolPoints2_Wave10);
        enemySpawner3.Spawn(patrolPoints3_Wave10);
    }

    void ReturnToMenu()
    {
        AudioManager.Instance.PlayMainTheme();
        gameManager.LoadScene(level);
    }

    void Update()
    {
        HandleWaveSpawning();

        GameObject[] EnemysAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if ((EnemysAlive.Length == 0) && (spawnsDoneInCurrentWave >= spawnsPerWave))
        {
            initialWave++;

            currentWave++;
            initialWave = currentWave;
            SetupWave(currentWave);
        }
    }

    private void SetupWave(int waveNumber)
    {
        spawnsDoneInCurrentWave = 0;
        nextSpawnTime = Time.time + spawnDelay;

        if (waveNumber == 10 && !wave10MusicPlayed)
        {
            wave10MusicPlayed = true;
            AudioManager.Instance.PlayWave10Music();
        }
    }

    private void HandleWaveSpawning()
    {
        if (spawnsDoneInCurrentWave >= spawnsPerWave)
            return;

        if (Time.time < nextSpawnTime)
            return;

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
            case 4:
                LoadWave4();
                break;
            case 5:
                LoadWave5();
                break;
            case 6:
                LoadWave6();
                break;
            case 7:
                LoadWave7();
                break;
            case 8:
                LoadWave8();
                break;
            case 9:
                LoadWave9();
                break;
            case 10:
                LoadWave10();
                break;
            case 11:
                ReturnToMenu();
                break;
        }

        spawnsDoneInCurrentWave++;
        nextSpawnTime = Time.time + spawnDelay;
    }
    public void ForceNextWave()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }

        spawnsDoneInCurrentWave = spawnsPerWave;

        Debug.Log("Forcing jump to next wave. ENEMIES DESTROYED.");
    }

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        if (newGameState == GameState.Gameplay)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }
}