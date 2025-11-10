using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject[] patrolPoints;
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
        Debug.Log("targetPoint: "+ targetPoint);
        Debug.Log("targetPointX: " + patrolPoints[targetPoint].transform.position.x);
        Debug.Log("targetPointY: " + patrolPoints[targetPoint].transform.position.y);
        Debug.Log("targetPointZ: " + patrolPoints[targetPoint].transform.position.z);

        Debug.Log("transform X: " + transform.position.x); 
        Debug.Log("transform Y: " + transform.position.y);
        Debug.Log("transform Z: " + transform.position.z);
        if (transform.position == patrolPoints[targetPoint].transform.position)
        {
            //increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].transform.position, speed * Time.deltaTime);
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
