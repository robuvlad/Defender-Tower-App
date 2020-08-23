using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = null;
    [SerializeField] GameObject enemy = null;

    private Transform currentPoint = null;
    private EnemySnail enemyBlackWheel = null;

    void Start()
    {
        currentPoint = waypoints[0];
        enemyBlackWheel = enemy.GetComponent<EnemySnail>() as EnemySnail;
    }

    void Update()
    {
        MoveTowardsNextPoint();
        UpdateCurrentPoint();
    }

    private void MoveTowardsNextPoint()
    {
        float distanceDelta = Time.deltaTime * enemyBlackWheel.Speed;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, currentPoint.position, distanceDelta);
    }

    private void UpdateCurrentPoint()
    {
        for(int i=0; i<waypoints.Capacity - 1; i++)
        {
            if (waypoints[i] == currentPoint)
            {
                currentPoint = waypoints[i + 1];
            }
        }
    }
}
