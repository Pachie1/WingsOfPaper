using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public GameObject canvas;

    [SerializeField] private InputActionReference enterAction;

    [Header("EnemyManager")]
    public GameObject enemymangerPF;
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
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //if (anyKey.triggered)
        if (enterAction.action.IsPressed())
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
            
            GameObject enemyMangerInst = Instantiate(enemymangerPF);
            EnemyManager enemyManagerScript = enemyMangerInst.GetComponent<EnemyManager>();

            enemyManagerScript.initialWave = initialWave;
            enemyManagerScript.enemySpawner1 = enemySpawner1;
            enemyManagerScript.enemySpawner2 = enemySpawner2;
            enemyManagerScript.enemySpawner3 = enemySpawner3;

            enemyManagerScript.patrolPoints1_Wave1 = patrolPoints1_Wave1;

            enemyManagerScript.patrolPoints1_Wave2 = patrolPoints1_Wave2;
            enemyManagerScript.patrolPoints2_Wave2 = patrolPoints2_Wave2;

            enemyManagerScript.patrolPoints1_Wave3 = patrolPoints1_Wave3;

            enemyManagerScript.patrolPoints1_Wave4 = patrolPoints1_Wave4;
            enemyManagerScript.patrolPoints2_Wave4 = patrolPoints2_Wave4;

            enemyManagerScript.patrolPoints1_Wave5 = patrolPoints1_Wave5;
            enemyManagerScript.patrolPoints2_Wave5 = patrolPoints2_Wave5;

            enemyManagerScript.patrolPoints1_Wave6 = patrolPoints1_Wave6;
            enemyManagerScript.patrolPoints2_Wave6 = patrolPoints2_Wave6;

            enemyManagerScript.patrolPoints1_Wave7 = patrolPoints1_Wave7;
            enemyManagerScript.patrolPoints2_Wave7 = patrolPoints2_Wave7;

            enemyManagerScript.patrolPoints1_Wave8 = patrolPoints1_Wave8;
            enemyManagerScript.patrolPoints2_Wave8 = patrolPoints2_Wave8;

            enemyManagerScript.patrolPoints1_Wave9 = patrolPoints1_Wave9;
            enemyManagerScript.patrolPoints2_Wave9 = patrolPoints2_Wave9;

            enemyManagerScript.patrolPoints1_Wave10 = patrolPoints1_Wave10;
            enemyManagerScript.patrolPoints2_Wave10 = patrolPoints2_Wave10;
            enemyManagerScript.patrolPoints3_Wave10 = patrolPoints3_Wave10;

            enemyMangerInst.SetActive(true); 
        }
    }
}
