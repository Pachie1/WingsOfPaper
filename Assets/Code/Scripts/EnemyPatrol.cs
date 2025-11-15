using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Vector3.Distance(transform.position, patrolPoints[targetPoint].position), 0))
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void increaseTargetInt() 
    {
        targetPoint++;
        if (patrolPoints.Length <= targetPoint)
        {
            targetPoint = 0;
        }
    }
}
