using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab; 
    public void Spawn(Transform[] patrolPoints)
    {
        GameObject enemy = Instantiate(prefab, transform.position, transform.rotation);

        EnemyPatrol patrol = enemy.GetComponent<EnemyPatrol>();
        patrol.patrolPoints = patrolPoints;
    }
    public GameObject prefabBoss;
    public void SpawnBoss(Transform[] patrolPoints)
    {
        GameObject enemy = Instantiate(prefabBoss, transform.position, transform.rotation);

        EnemyPatrol patrol = enemy.GetComponent<EnemyPatrol>();
        patrol.patrolPoints = patrolPoints;
    }
}