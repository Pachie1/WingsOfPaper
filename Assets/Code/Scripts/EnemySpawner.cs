/*using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject prefab;
    private EnemyPatrol patrol;
    private ObjectPool enemyPool;

    public void Spawn(Transform[] patrolPointsWave1)
    {
        patrol = prefab.GetComponent<EnemyPatrol>();

        patrol.patrolPoints = patrolPointsWave1;

        prefab.transform.position = transform.position;
        prefab.transform.rotation = transform.rotation;

        Instantiate(prefab);
    }

    public void DeactivateEnenmy(GameObject enemy)
    {
        enemyPool.ReturnObject(enemy);
    }
}*/


using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public EnemyManager manager;  

    public void Spawn(Transform[] patrolPoints)
    {
        GameObject enemy = Instantiate(prefab, transform.position, transform.rotation);

        EnemyPatrol patrol = enemy.GetComponent<EnemyPatrol>();
        patrol.patrolPoints = patrolPoints;

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.enemyManagerGO = manager.gameObject;

        manager.enemyHasSpawned();
    }
}