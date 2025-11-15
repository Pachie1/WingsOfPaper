using UnityEngine;

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
}
