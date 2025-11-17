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